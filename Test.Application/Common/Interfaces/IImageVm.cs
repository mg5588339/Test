namespace Test.Application.Common.Interfaces
{
    public interface IImageVm
    {
        string ImageAlt { get; set; }
        string ImageName { get; set; }
        string ImageFullName { get; }
        string Base64Input { get; set; }
        string[] ThumbnailSizes { get; }

    }
}
