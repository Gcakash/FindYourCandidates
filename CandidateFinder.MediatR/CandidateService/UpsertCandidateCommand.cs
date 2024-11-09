using CandidateFinder.Data.CandidateFinderDbContext;
using CandidateFinder.Data.Mapper;
using CandidateFinder.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CandidateFinder.MediatRService.CandidateService
{
    public record UpsertCandidateCommand(CandidateDTO candidate) : IRequest<ResponseModel<CandidateDTO>>;

    public record UpsertCandidateCommandHandler(AppllicationDbContext _dbContext) :
        IRequestHandler<UpsertCandidateCommand, ResponseModel<CandidateDTO>>
    {
        public async Task<ResponseModel<CandidateDTO>> Handle(UpsertCandidateCommand request, CancellationToken cancellationToken)
        {
            ResponseModel<CandidateDTO> response = new();
            string errorMessage = String.Empty;
            if (String.IsNullOrWhiteSpace(request.candidate.Email))
            {
                errorMessage += "Email is required";
            }
            if (!String.IsNullOrWhiteSpace(errorMessage))
            {
                response.Error = new ErrorModel { ErrorMessage = errorMessage };
            }
            else
            {
                var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.Email == request.candidate.Email);
                if (candidate == null)
                {
                    var dbCandidate = request.candidate.ConvertToEntity(new Candidate());
                     _dbContext.Candidates.Add(dbCandidate);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    response.Result = dbCandidate.ConvertToDTO();

                }
                else
                {
                    var dbCandidate = request.candidate.ConvertToEntity(candidate);
                    _dbContext.Candidates.Update(dbCandidate);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    response.Result = dbCandidate.ConvertToDTO();
                }
            }
            return response;
        }
    }
}
