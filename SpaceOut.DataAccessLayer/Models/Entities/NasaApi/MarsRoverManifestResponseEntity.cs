using SpaceOut.Shared.Models.Responses;

namespace SpaceOut.DataAccessLayer.Models.Entities.NasaApi;

public class MarsRoverManifestResponseEntity : OperationResultResponse
{
    public MarsRoverPhotoManifestEntity? Photo_Manifest { get; set; }
}

public class MarsRoverPhotoManifestEntity
{
    public string Name { get; set; } = string.Empty;
    public string Landing_Date { get; set; } = string.Empty;
    public string Launch_Date { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Max_Sol { get; set; } = 0;
    public string Max_Date { get; set; } = string.Empty;
    public int Total_Photos { get; set; } = 0;
    public List<MarsRoverPhotosEntity> Photos { get; set; } = new List<MarsRoverPhotosEntity>();
}

public class MarsRoverPhotosEntity
{
    public int Sol { get; set; } = 0;
    public string Earth_Date { get; set; } = string.Empty;
    public int Total_Photos { get; set; } = 0;
    public List<string>? Cameras { get; set; }
}

//{" photo_manifest":
//      {   "name":"Curiosity",
//          "landing_date":"2012-08-06",
//          "launch_date":"2011-11-26",
//          "status":"active",
//          "max_sol":3660,
//          "max_date":"2022-11-22",
//          "total_photos":612032,
//          "photos":[  {   "sol":0,
//                          "earth_date":"2012-08-06",
//                          "total_photos":3702,
//                          "cameras":["CHEMCAM","FHAZ","MARDI","RHAZ"]},
//                      {   "sol":1,
//                          "earth_date":"2012-08-07",
//                          "total_photos":16,
//                          "cameras":["MAHLI","MAST","NAVCAM"]},
//                      {   "sol":2,
//                          "earth_date":"2012-08-08",
//                          "total_photos":74,"cameras":["NAVCAM"]},