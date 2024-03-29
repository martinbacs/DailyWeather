﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    var southWest = L.latLng(52.500440,2.250475);
    var northEast = L.latLng(70.742227,37.934697);
bounds = L.latLngBounds(southWest, northEast);
var mymap = L.map('mapid', {
            minZoom: 4,
        maxZoom: 9,

    maxBounds: bounds
}).setView([62.161, 15.311], 4);

L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    maxZoom: 18,
    id: 'mapbox.streets',
    accessToken: 'pk.eyJ1IjoibWFyYmFjIiwiYSI6ImNqeTdvc2dmejAxbnAzaHAxOHF5ZWVzMXgifQ.G42i7HcUkTVvFKd-8rG5ZQ'
    }).addTo(mymap);

var popup = L.popup();

function onMapClick(e) {
    popup
        .setLatLng(e.latlng)
        .setContent("You clicked the map at " + e.latlng.toString())
        .openOn(mymap);

            $.ajax({
            type: "GET",
            url: '../Forecast/Forecast?lng=' + e.latlng.lng + '&lat=' + e.latlng.lat,
            success: function (data) {
               document.getElementById("main-content").innerHTML = data;
                }
        });

}

mymap.on('click', onMapClick);

/*
function load() {
     $.ajax({
     type: "GET",
     url: '',
     success: function(data){
         document.getElementById("").innerHTML = data;
     }
     });
     

}
*/