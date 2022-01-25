using _01_HA_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Slide
{
       public class Slide : EntityBase<long>
        {
            public string PictureSource { get; private set; }
            public string PictureAlt { get; private set; }
            public string PictureTitle { get; private set; }
            public string Heading { get; private set; }
            public string Title { get; private set; }
            public string Text { get; private set; }
            public string BtnText { get; private set; }
            public string Link { get; private set; }
            public bool IsRemoved { get; private set; }

            public Slide(string pictureSource, string pictureAlt, string pictureTitle, string heading,
                string title, string text, string link, string btnText)
            {
            PictureSource = pictureSource;
                PictureAlt = pictureAlt;
                PictureTitle = pictureTitle;
                Heading = heading;
                Title = title;
                Text = text;
                BtnText = btnText;
                Link = link;
                IsRemoved = false;
            }

            public void Update(string pictureSource, string pictureAlt, string pictureTitle, string heading,
                string title, string text, string link, string btnText)
            {
                if (!string.IsNullOrWhiteSpace(pictureSource))
                PictureSource = pictureSource;

                PictureAlt = pictureAlt;
                PictureTitle = pictureTitle;
                Heading = heading;
                Title = title;
                Text = text;
                BtnText = btnText;
                Link = link;
            }

            public void Remove()
            {
                IsRemoved = true;
            }

            public void Restore()
            {
                IsRemoved = false;
            }
        }
    }

