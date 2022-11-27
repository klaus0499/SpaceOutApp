using System.Net.Http.Json;
using SpaceOut.DataAccessLayer.Models.Entities.NasaApi;

namespace SpaceOut.DataAccessLayer.Repositories;

public class NasaRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _nasaApiLicenseKey;

    public NasaRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.nasa.gov/");
        _nasaApiLicenseKey = "api_key=oDIiUSmV3rzdEeaox9Z1gDqfcJ3403DrhhiLwuob";
    }

    // Specifically: GET https://api.nasa.gov/planetary/apod 
    // Query Parameters
    //    Parameter     Type                Default Description
    //    date          YYYY-MM-DD today    The date of the APOD image to retrieve
    //    start_date    YYYY-MM-DD none     The start of a date range, when requesting date for a range of dates.
    //                                      Cannot be used with date.
    //    end_date      YYYY-MM-DD today    The end of the date range, when used with start_date.
    //    count         int none            If this is specified then count randomly chosen images will be returned.
    //                                      Cannot be used with date or start_date and end_date.
    //    thumbs        bool False          Return the URL of video thumbnail. If an APOD is not a video, this parameter is ignored.
    //    api_key       string DEMO_KEY     api.nasa.gov key for expanded usage
    //    https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY
    public async Task<ApodResponseEntity> GetApod(ApodRequestEntity request)
    {
        // APODs are valid from 20-06-1995 and onwards
        ApodResponseEntity? apodResponseEntity = null; 
        string requestString = "planetary/apod" + "?" + _nasaApiLicenseKey;
        string requestDate = request.StartDate.Date.Year.ToString() + "-" + request.StartDate.Date.Month.ToString() + "-" + request.StartDate.Date.Day.ToString();
        requestString = requestString + "&date=" + requestDate;
        try { 
            apodResponseEntity = await _httpClient.GetFromJsonAsync<ApodResponseEntity>(requestString);
            if (apodResponseEntity is null)
            {
                apodResponseEntity= new ApodResponseEntity();
                apodResponseEntity.Success = false;
                apodResponseEntity.Error = true;
                apodResponseEntity.ErrorMessage = "No APOD data available for the requested date: " + requestDate;
            } 
            else 
            { 
                apodResponseEntity.Success = true;
                apodResponseEntity.Error = false;
                apodResponseEntity.ErrorMessage = "";
            }
        }
        catch (HttpRequestException ex)
        {
            apodResponseEntity = new ApodResponseEntity();
            apodResponseEntity.Success = false;
            apodResponseEntity.Error = true;
            switch (ex.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest: apodResponseEntity.ErrorMessage = "400 Bad Request"; break;
                case System.Net.HttpStatusCode.Unauthorized: apodResponseEntity.ErrorMessage = "401 Unauthorized"; break;
                case System.Net.HttpStatusCode.Forbidden: apodResponseEntity.ErrorMessage = "403 Forbidden"; break;
                case System.Net.HttpStatusCode.NotFound: apodResponseEntity.ErrorMessage = "404 Not Found"; break;
                default: break;
            }
        }
        return apodResponseEntity;
    }

    public async Task<List<ApodResponseEntity>> GetApodCount(ApodRequestEntity request)
    {
        List<ApodResponseEntity>? apodResponseEntityList = null;
        string requestString = "planetary/apod" + "?" + _nasaApiLicenseKey;
        requestString = requestString + "&count=" + request.Count;
        try
        {
            apodResponseEntityList = await _httpClient.GetFromJsonAsync<List<ApodResponseEntity>>(requestString);
            if (apodResponseEntityList is null)
            {
                apodResponseEntityList = new List<ApodResponseEntity>();
                ApodResponseEntity apodResponseEntity = new ApodResponseEntity();
                apodResponseEntity.Success = false;
                apodResponseEntity.Error = true;
                apodResponseEntity.ErrorMessage = "No APOD data available for the requested count: " + request.Count;
                apodResponseEntityList.Add(apodResponseEntity);
            }
            else
            { 
                // Make sure all retrieved entities are marked as a success response
                for (int i = 0; i < apodResponseEntityList.Count; i++) {
                    apodResponseEntityList[i].Success = true;
                    apodResponseEntityList[i].Error = false;
                    apodResponseEntityList[i].ErrorMessage = "";
                }
            }
        }
        catch (HttpRequestException ex)
        {
            apodResponseEntityList = new List<ApodResponseEntity>();
            ApodResponseEntity apodResponseEntity = new ApodResponseEntity();
            apodResponseEntity.Success = false;
            apodResponseEntity.Error = true;
            switch (ex.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest: apodResponseEntity.ErrorMessage = "400 Bad Request"; break;
                case System.Net.HttpStatusCode.Unauthorized: apodResponseEntity.ErrorMessage = "401 Unauthorized"; break;
                case System.Net.HttpStatusCode.Forbidden: apodResponseEntity.ErrorMessage = "403 Forbidden"; break;
                case System.Net.HttpStatusCode.NotFound: apodResponseEntity.ErrorMessage = "404 Not Found"; break;
                default: break;
            }
            apodResponseEntityList.Add(apodResponseEntity);
        }
        return apodResponseEntityList;
    }

    public async Task<MarsRoverManifestResponseEntity> GetMarsRoverManifest(MarsRoverManifestRequestEntity marsRoverManifestRequestEntity)
    {
        MarsRoverManifestResponseEntity? marsRoverManifestResponseEntity = null;
        string requestString = "mars-photos/api/v1/manifests/" + marsRoverManifestRequestEntity.Name + "?" + _nasaApiLicenseKey;
        try
        {
            marsRoverManifestResponseEntity = await _httpClient.GetFromJsonAsync<MarsRoverManifestResponseEntity>(requestString);
            if (marsRoverManifestResponseEntity is null)
            {
                marsRoverManifestResponseEntity = new MarsRoverManifestResponseEntity();
                marsRoverManifestResponseEntity.Success = false;
                marsRoverManifestResponseEntity.Error = true;
                marsRoverManifestResponseEntity.ErrorMessage = "No Rover Manifest data available for the requested rover: " + marsRoverManifestRequestEntity.Name;
            }
            else
            {
                marsRoverManifestResponseEntity.Success = true;
                marsRoverManifestResponseEntity.Error = false;
                marsRoverManifestResponseEntity.ErrorMessage = "";
            }
        }
        catch (HttpRequestException ex)
        {
            marsRoverManifestResponseEntity = new MarsRoverManifestResponseEntity();
            marsRoverManifestResponseEntity.Success = false;
            marsRoverManifestResponseEntity.Error = true;
            switch (ex.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest: marsRoverManifestResponseEntity.ErrorMessage = "400 Bad Request"; break;
                case System.Net.HttpStatusCode.Unauthorized: marsRoverManifestResponseEntity.ErrorMessage = "401 Unauthorized"; break;
                case System.Net.HttpStatusCode.Forbidden: marsRoverManifestResponseEntity.ErrorMessage = "403 Forbidden"; break;
                case System.Net.HttpStatusCode.NotFound: marsRoverManifestResponseEntity.ErrorMessage = "404 Not Found"; break;
                default: break;
            }
        }
        return marsRoverManifestResponseEntity;

    }

    // Mars Rover API
    // Get rover manifest: https://api.nasa.gov/mars-photos/api/v1/manifests/curiosity?api_key=DEMO_KEY
    // {" photo_manifest":
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
    //
    // Get rover manifest: https://api.nasa.gov/mars-photos/api/v1/manifests/spirit?api_key=DEMO_KEY 
    // {" photo_manifest":
    //      {   "name":"Spirit",
    //          "landing_date":"2004-01-04",
    //          "launch_date":"2003-06-10",
    //          "status":"complete",
    //          "max_sol":2208,
    //          "max_date":"2010-03-21",
    //          "total_photos":124550,
    //          "photos":[  {   "sol":1,
    //                          "earth_date":"2004-01-05",
    //                          "total_photos":77,
    //                          "cameras":["ENTRY","FHAZ","NAVCAM","PANCAM","RHAZ"]},
    //                      {   "sol":2,
    //                          "earth_date":"2004-01-06",
    //                          "total_photos":125,
    //                          "cameras":["MINITES","NAVCAM","PANCAM"]},
    //                      {   "sol":3,
    //                          "earth_date":"2004-01-07",
    //                          "total_photos":125,
    //                          "cameras":["NAVCAM","PANCAM","RHAZ"]}
    //
    // Get rover manifest: https://api.nasa.gov/mars-photos/api/v1/manifests/opportunity?api_key=DEMO_KEY
    // {" photo_manifest":
    //      {   "name":"Opportunity",
    //          "landing_date":"2004-01-25",
    //          "launch_date":"2003-07-07",
    //          "status":"complete",
    //          "max_sol":5111,
    //          "max_date":"2018-06-11",
    //          "total_photos":198439,
    //          "photos":[  {   "sol":1,
    //                          "earth_date":"2004-01-26",
    //                          "total_photos":95,
    //                          "cameras":["ENTRY","FHAZ","NAVCAM","PANCAM","RHAZ"]},
    //                      {   "sol":2,
    //                          "earth_date":"2004-01-27",
    //                          "total_photos":280,
    //                          "cameras":["MINITES","NAVCAM","PANCAM"]},
    //                      {   "sol":3,
    //                          "earth_date":"2004-01-28",
    //                          "total_photos":321,
    //                          "cameras":["NAVCAM","PANCAM","RHAZ"]},

    public async Task<MarsRoverDateCameraPhotoListResponseEntity> GetMarsRoverDateCameraPhotoList(MarsRoverDateCameraPhotoListRequestEntity marsRoverDateCameraPhotoListRequestEntity)
    {
        MarsRoverDateCameraPhotoListResponseEntity? marsRoverDateCameraPhotoListResponseEntity = null;
        string requestString = "mars-photos/api/v1/rovers/" + marsRoverDateCameraPhotoListRequestEntity.RoverName + "/photos?" +
                               "earth_date=" + marsRoverDateCameraPhotoListRequestEntity.EarthDate + "&" + 
                               "camera=" + marsRoverDateCameraPhotoListRequestEntity.CameraName + "&" + 
                               _nasaApiLicenseKey;
        try
        {
            marsRoverDateCameraPhotoListResponseEntity = await _httpClient.GetFromJsonAsync<MarsRoverDateCameraPhotoListResponseEntity>(requestString);
            if (marsRoverDateCameraPhotoListResponseEntity is null)
            {
                marsRoverDateCameraPhotoListResponseEntity = new MarsRoverDateCameraPhotoListResponseEntity();
                marsRoverDateCameraPhotoListResponseEntity.Success = false;
                marsRoverDateCameraPhotoListResponseEntity.Error = true;
                marsRoverDateCameraPhotoListResponseEntity.ErrorMessage = "No photos available for rover: " + marsRoverDateCameraPhotoListRequestEntity.RoverName +
                                                                          " on earth date: " + marsRoverDateCameraPhotoListRequestEntity.EarthDate + 
                                                                          " with camera name: " + marsRoverDateCameraPhotoListRequestEntity.CameraName;
            }
            else
            {
                marsRoverDateCameraPhotoListResponseEntity.Success = true;
                marsRoverDateCameraPhotoListResponseEntity.Error = false;
                marsRoverDateCameraPhotoListResponseEntity.ErrorMessage = "";
            }
        }
        catch (HttpRequestException ex)
        {
            marsRoverDateCameraPhotoListResponseEntity = new MarsRoverDateCameraPhotoListResponseEntity();
            marsRoverDateCameraPhotoListResponseEntity.Success = false;
            marsRoverDateCameraPhotoListResponseEntity.Error = true;
            switch (ex.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest: marsRoverDateCameraPhotoListResponseEntity.ErrorMessage = "400 Bad Request"; break;
                case System.Net.HttpStatusCode.Unauthorized: marsRoverDateCameraPhotoListResponseEntity.ErrorMessage = "401 Unauthorized"; break;
                case System.Net.HttpStatusCode.Forbidden: marsRoverDateCameraPhotoListResponseEntity.ErrorMessage = "403 Forbidden"; break;
                case System.Net.HttpStatusCode.NotFound: marsRoverDateCameraPhotoListResponseEntity.ErrorMessage = "404 Not Found"; break;
                default: break;
            }
        }
        return marsRoverDateCameraPhotoListResponseEntity;
    }
}
