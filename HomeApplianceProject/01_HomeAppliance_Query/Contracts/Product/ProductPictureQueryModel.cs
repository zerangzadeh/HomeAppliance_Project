﻿namespace _01_LampshadeQuery.Contracts.Product
{
    public class ProductPictureQueryModel
    {
        public long ProductID { get; set; }
        public string PictureSource { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemoved { get; set; }
    }

}
