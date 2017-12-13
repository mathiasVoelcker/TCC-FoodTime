angular.module('app').controller('SugerirEstabelecimentoController', function ($scope, $routeParams, authService, estabService, fotoService, categoriaService, $http) {

  $scope.estabelecimento = { }
  $scope.estabelecimento.Endereco = { }
  $scope.estabelecimento.Fotos = []
  $scope.estabelecimento.idCategorias = []
  $scope.estabelecimento.idFotos = []

  $scope.buscouEstab = false

  categoriaService.listar().then(
    function (response) {
      $scope.categorias = response.data;
      console.log($scope.categorias)
    }
  );

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
    $scope.buscouEstab = true
    $scope.estabelecimento.Nome = place.name
    $scope.estabelecimento.Endereco.Latitude = place.geometry.location.lat();
    $scope.estabelecimento.Endereco.Longitude = place.geometry.location.lng();
    $scope.$apply();
    // $scope.estabelecimento.latitude = place.geometry.location.lat();
    // $scope.estabelecimento.longitude = place.geometry.location.lng();
    return;
  }

  $scope.cadastrarEstabelecimento = function(estabelecimento){
    if(sugerirEstabelecimento.$valid){
      var file = document.getElementById('file').files[0];
      var fd = new FormData();
      fd.append('file', file);
      if(file != undefined){
        estabelecimento.Fotos.push(file.name);
        fotoService.addFoto(fd).then(
          function(response){
            console.log("Foto adicionada com sucesso!");
          }, function(response){
          }
        )};
        console.log(estabelecimento)
        estabService.criarEstabelecimento(estabelecimento).then(
          function(response){
            alert("Estabelecimento Cadastrado com sucesso")
            console.log(response)
          }
        )
      }
    }



  })