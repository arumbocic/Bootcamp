namespace TractorModel.Common
{
    public interface IFilterTractorModel
    {
        int Id { get; set; }
        string Model { get; set; }
        int BrandId { get; set; }
    }
}