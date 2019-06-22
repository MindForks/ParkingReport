// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(useLocation);
    }
};

function useLocation(position) {
    window.location.replace('?longitude=' + position.coords.longitude + '&latitude=' + position.coords.latitude);
};