namespace SpaceOut.BusinessLogicLayer.Models.DTOs.NasaApi;

public class MarsRoverDateCameraPhotoListRequestDto
{
    public string RoverName { get; set; } = string.Empty;
    public string EarthDate { get; set; } = string.Empty;
    public string CameraName { get; set; } = string.Empty;
}

//{"photos":
//  [
//   { "id":108888,"sol":1,"camera": { "id":19,"name":"ENTRY","rover_id":6,"full_name":"Entry, Descent, and Landing Camera"},"img_src":"http://mars.nasa.gov/mer/gallery/all/1/e/001/1E128278505EDN0000F0006N0M1-BR.JPG","earth_date":"2004-01-26","rover":{ "id":6,"name":"Opportunity","landing_date":"2004-01-25","launch_date":"2003-07-07","status":"complete"}},
//   { "id":108889,"sol":1,"camera": { "id":19,"name":"ENTRY","rover_id":6,"full_name":"Entry, Descent, and Landing Camera"},"img_src":"http://mars.nasa.gov/mer/gallery/all/1/e/001/1E128278509EDN0000F0006N0M1-BR.JPG","earth_date":"2004-01-26","rover":{ "id":6,"name":"Opportunity","landing_date":"2004-01-25","launch_date":"2003-07-07","status":"complete"}},
//   { "id":108890,"sol":1,"camera": { "id":19,"name":"ENTRY","rover_id":6,"full_name":"Entry, Descent, and Landing Camera"},"img_src":"http://mars.nasa.gov/mer/gallery/all/1/e/001/1E128278513EDN0000F0006N0M1-BR.JPG","earth_date":"2004-01-26","rover":{ "id":6,"name":"Opportunity","landing_date":"2004-01-25","launch_date":"2003-07-07","status":"complete"}}
//  ]
//}