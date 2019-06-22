$(document).ready(function() {
    
    $('[data-toggle=offcanvas]').click(function() {
        $('.row-offcanvas').toggleClass('active');
    });
  
});

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(useLocation);
    }
};

function useLocation(position) {
    window.location.replace('?longitude=' + position.coords.longitude + '&latitude=' + position.coords.latitude);
};