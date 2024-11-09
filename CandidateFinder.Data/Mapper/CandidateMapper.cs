using CandidateFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CandidateFinder.Data.Mapper
{
    public static class CandidateMapper
    {

        public static Candidate ConvertToEntity(this CandidateDTO self, Candidate candidateEntity)
        {

            candidateEntity.FirstName = self.FirstName;
            candidateEntity.LastName = self.LastName;
            candidateEntity.PhoneNumber = self.PhoneNumber;
            candidateEntity.Email = self.Email;
            candidateEntity.PreferredCallTime = self.PreferredCallTime;
            candidateEntity.LinkedInUrl = self.LinkedInUrl;
            candidateEntity.GitHubUrl = self.GitHubUrl;
            candidateEntity.Comment = self.Comment;

            return candidateEntity;
        }
        public static CandidateDTO ConvertToDTO(this Candidate self)
        {
            return new CandidateDTO()
            {
                Id = self.Id,
                FirstName = self.FirstName,
                LastName = self.LastName,
                PhoneNumber = self.PhoneNumber,
                Email = self.Email,
                PreferredCallTime = self.PreferredCallTime,
                LinkedInUrl = self.LinkedInUrl,
                GitHubUrl = self.GitHubUrl,
                Comment = self.Comment,
            };        
        }
    }
}
