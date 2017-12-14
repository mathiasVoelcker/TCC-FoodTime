angular.module('app').config(["$sceDelegateProvider", function($sceDelegateProvider) {
    $sceDelegateProvider.resourceUrlWhitelist([
        // Allow same origin resource loads.
        "self",
        // Allow loading from Google maps
        "https://www.google.com/maps/embed/v1/place**"
    ]);
}]);
