﻿using System.Net.Http.Json;
using SpaceOut.DataAccessLayer.Models.Entities.NasaApi;

namespace SpaceOut.DataAccessLayer.Repositories;

public class NasaRepository
{
    private readonly HttpClient _httpClient;
    private readonly string _nasaApiLicenseKey;

    public NasaRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.nasa.gov/planetary/");
        _nasaApiLicenseKey = "apod?api_key=DEMO_KEY";
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
        // Valid from 20-06-1995
        string requestString = _nasaApiLicenseKey;
        requestString = requestString + "&date=" +
                        request.StartDate.Date.Year.ToString() + "-" +
                        request.StartDate.Date.Month.ToString() + "-" +
                        request.StartDate.Date.Day.ToString();
        ApodResponseEntity apodResponse = await _httpClient.GetFromJsonAsync<ApodResponseEntity>(requestString);
        return apodResponse;
    }

}