var buildingApp = buildingApp || {};
buildingApp.initialize = () => {
    marker = null;
    var latlng = new google.maps.LatLng(24.8049071, 46.6935335);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), options);
    map.addListener('click', function (e) {
        buildingApp.placeMarker(e.latLng, map);
        latlng = e.latLng;
        return e.latLng.toUrlValue();
    });

    return latlng.toUrlValue();
}
var marker;
buildingApp.placeMarker = (location, map) => {
    if (marker) {
        marker.setPosition(location);
    } else {
        marker = new google.maps.Marker({
            position: location,
            map: map
        });
    }
}
