function initializeMap(mapRoute) {
    var map = L.map('mapContainer',).setView([1.3, 103.85], 11);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        minZoon: 7,
        maxZoom: 25,
        attribution: '&copy;<a href="http://www.openstreetmap.org/copyright"> OpenStreetMap</a>'
    }).addTo(map);

    //var marker = L.marker([51.5, -0.09]).addTo(map);

    //var circle = L.circle([51.508, -0.11], {
    //    color: 'red',
    //    fillColor: '#f03',
    //    fillOpacity: 0.5,
    //    radius: 500
    //}).addTo(map);

    //var polygon = L.polygon([
    //    [51.509, -0.08],
    //    [51.503, -0.06],
    //    [51.51, -0.047]
    //]).addTo(map);

    var arrivalIcon = L.icon({
        iconUrl: '/css/images/flight-arrival-icon.png',
        shadowUrl: '/css/images/marker-shadow.png',

        iconSize: [42, 52], // size of the icon
        shadowSize: [1, 1], // size of the shadow
        iconAnchor: [-2, 48], // point of the icon which will correspond to marker's location
        shadowAnchor: [50, 68],  // the same for the shadow
        popupAnchor: [-31, -46] // point from which the popup should open relative to the iconAnchor
    });
    
    var departureIcon = L.icon({
        iconUrl: '/css/images/flight-departure-icon.png',
        shadowUrl: '/css/images/marker-shadow.png',

        iconSize: [42, 52], // size of the icon
        shadowSize: [1, 1], // size of the shadow
        iconAnchor: [48, 48], // point of the icon which will correspond to marker's location
        shadowAnchor: [50, 68],  // the same for the shadow
        popupAnchor: [-31, -46] // point from which the popup should open relative to the iconAnchor
    });


    //"${(waypoint.seqNum+1)"
    var markerConfig = {};
    var waypoints = mapRoute.map(function (waypoint) {
        if (waypoint.airway == 'Departure') markerConfig = { icon: departureIcon }
        else if (waypoint.airway == 'Arrival') markerConfig = { icon: arrivalIcon }
        else {
            var seqNum = waypoint.seqNum + 1;
            markerConfig = {
                icon: L.divIcon({
                    className: "number-marker-icon",
                    html: `<span><strong>${seqNum}</strong></span>`,
                    iconAnchor: [20, 20], 
                    popupAnchor: [-2, -22],
                })
            }
        }

        var layer = L.marker([waypoint.latitude, waypoint.longitude], markerConfig).addTo(map)
            .bindPopup(
                (waypoint.airway == 'Departure' || waypoint.airway == 'Arrival' ? waypoint.airway + ':' : waypoint.seqNum + 1 + '.')
                + waypoint.designatedPoint
                + ((waypoint.speedCode + waypoint.levelCode == '') ? '' : '/' + waypoint.speedCode + waypoint.levelCode)
                + ((waypoint.airway == 'Departure' || waypoint.airway == 'Arrival' || waypoint.airway == '') ? '' : '<br>Airway:' + waypoint.airway)
                + ('<br>Latitude:' + waypoint.latitude)
                + ('<br>Longitude:' + waypoint.longitude)
        );

        if (layer._icon.className.includes("number-marker-icon")) {
            // when marker is clicked
            layer.on("click", () => {
                layer._icon.classList.add("animation");
            });

            // remove class when popup is closed
            layer.on("popupclose", () => {
                layer._icon.classList.remove("animation");
            });
        }

        return L.latLng(waypoint.latitude, waypoint.longitude);
    });

    var polyline = L.polyline(waypoints, { color: 'blue', weight: 3 }).addTo(map);
    map.fitBounds(polyline.getBounds());
}