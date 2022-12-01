using SpaceOut.Shared.Models.Responses;

namespace SpaceOut.DataAccessLayer.Models.Entities.NasaApi;

public class MarsRoverDateCameraPhotoListResponseEntity : OperationResultResponse
{
    public List<MarsRoverDateCameraPhotoEntity> Photos { get; set; } = new List<MarsRoverDateCameraPhotoEntity>();
}

public class MarsRoverDateCameraPhotoEntity
{
    public int Id { get; set; } = 0;
    public int Sol { get; set; } = 0;
    public MarsRoverCameraDataEntity Camera { get; set; } = new();
    public string Img_Src { get; set; } = string.Empty;
    public string Earth_Date { get; set; } = string.Empty;
    public MarsRoverDataEntity Rover { get; set; } = new();
}

public class MarsRoverCameraDataEntity
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public int Rover_Id { get; set; } = 0;
    public string Full_Name { get; set; } = string.Empty;
}

public class MarsRoverDataEntity
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Landing_Date { get; set; } = string.Empty;
    public string Launch_Date { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

//{
// "photos":
//  [
//   {
//      "id":108888,
//      "sol":1,
//      "camera": {
//          "id":19,
//          "name":"ENTRY",
//          "rover_id":6,
//          "full_name":"Entry, Descent, and Landing Camera"
//      },
//      "img_src":"http://mars.nasa.gov/mer/gallery/all/1/e/001/1E128278505EDN0000F0006N0M1-BR.JPG",
//      "earth_date":"2004-01-26",
//      "rover": {
//          "id":6,
//          "name": "Opportunity",
//          "landing_date":"2004-01-25",
//          "launch_date":"2003-07-07",
//          "status":"complete"
//      }
//   },
//   { "id":108889,"sol":1,"camera": { "id":19,"name":"ENTRY","rover_id":6,"full_name":"Entry, Descent, and Landing Camera"},"img_src":"http://mars.nasa.gov/mer/gallery/all/1/e/001/1E128278509EDN0000F0006N0M1-BR.JPG","earth_date":"2004-01-26","rover":{ "id":6,"name":"Opportunity","landing_date":"2004-01-25","launch_date":"2003-07-07","status":"complete"}},
//   { "id":108890,"sol":1,"camera": { "id":19,"name":"ENTRY","rover_id":6,"full_name":"Entry, Descent, and Landing Camera"},"img_src":"http://mars.nasa.gov/mer/gallery/all/1/e/001/1E128278513EDN0000F0006N0M1-BR.JPG","earth_date":"2004-01-26","rover":{ "id":6,"name":"Opportunity","landing_date":"2004-01-25","launch_date":"2003-07-07","status":"complete"}}
//  ]
//}