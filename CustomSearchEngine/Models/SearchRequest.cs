using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.Models
{
    public class SearchRequest : IValidatableObject
    {
        [Required]
        public string Keywords { get; set; }

        [Required]
        public string MatchUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (MatchUrl.StartsWith("https://") || MatchUrl.StartsWith("http://"))
            {
                validationResults.Add(new ValidationResult($"{nameof(MatchUrl)} must not contain http or https protocol prefix"));
            }
            return validationResults;
        }
    }
}
