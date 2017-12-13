angular.module('app').controller('SugerirEstabelecimentoController', function ($scope, $routeParams, authService, estabService, $http) {

  autoComplete();
  var origem;
  var destino = {lat: -29.794918, lng: -51.146509}

  function autoComplete() {
    $scope.autocomplete = new google.maps.places.Autocomplete(
      (document.getElementById('autocomplete'))
    );
    $scope.autocomplete.addListener('place_changed', obterCoordenadas);
  }

  function obterCoordenadas() {
    var place = $scope.autocomplete.getPlace();
    console.log(place)
    // $scope.estabelecimento.latitude = place.geometry.location.lat();
    // $scope.estabelecimento.longitude = place.geometry.location.lng();
    return;
  }

})
