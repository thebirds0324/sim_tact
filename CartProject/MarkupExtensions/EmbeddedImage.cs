using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CartProject.MarkupExtensions
{
    [ContentProperty("ResourceId")]

    public class EmbeddedImage : IMarkupExtension
    {
        //리소스Id를 받기위한 Property
        public string ResourceId { get; set; }

        //이 메소드에서 Object(Image)를 반환
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            //null 입력 방지
            if (String.IsNullOrWhiteSpace(ResourceId))
            {
                return null;
            }
            return ImageSource.FromResource(ResourceId);
        }
    }
}
