using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace P208_ASP_Front.Models
{
    [MetadataType(typeof(SliderMetadata))]
    public partial class Slider
    {
        private class SliderMetadata
        {
            [Required(ErrorMessage = "Title doldurulmalidir")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Subtitle doldurulmalidir")]
            public string SubTitle { get; set; }
        }
    }
}