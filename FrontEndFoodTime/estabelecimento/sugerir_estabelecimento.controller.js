angular.module('app').controller('SugerirEstabelecimentoController', function ($scope, $routeParams, $location, authService, estabService, fotoService, categoriaService, $http) {

  $scope.estabelecimento = { }
  $scope.estabelecimento.Endereco = { }
  $scope.estabelecimento.Fotos = []
  $scope.estabelecimento.idCategorias = []
  $scope.estabelecimento.idFotos = []
  $scope.estabelecimento.IdPreferencias = []

  $scope.buscouEstab = false

  categoriaService.listar().then(
    function (response) {
      $scope.categorias = response.data;
      console.log($scope.categorias)
    }
  );

  autoComplete();

  function autoComplete() {
    $scope.autocomplete = new google.maps.places.Autocomplete(document.getElementById('autocomplete'));
    $scope.autocomplete.setTypes(['establishment']);
    $scope.autocomplete.addListener('place_changed', atribuirDadosAEscopo);
  }

  function redirecionar(){
    $location.path("/#!/home");
  }

  function atribuirDadosAEscopo() {
    var place = $scope.autocomplete.getPlace();
    console.log(place)
    $scope.buscouEstab = true
    $scope.estabelecimento.Nome = place.name
    $scope.estabelecimento.Endereco.Latitude = place.geometry.location.lat();
    $scope.estabelecimento.Endereco.Longitude = place.geometry.location.lng();
    $scope.$apply();
    return;
  }


  $scope.adicionarPreferencias = function (idPreferencia) {
    $scope.estabelecimento.IdPreferencias.push(idPreferencia)
    console.log($scope.estabelecimento.IdPreferencias)
  }

  $scope.removerPreferencias = function(idPreferencia){
    $scope.estabelecimento.IdPreferencias.splice(($scope.estabelecimento.IdPreferencias.indexOf(idPreferencia)), 1);
    console.log($scope.estabelecimento.IdPreferencias)
  }

  $scope.cadastrarEstabelecimento = function(estabelecimento){
    if($scope.sugerirEstabelecimento.$valid){
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
            redirecionar();
          }
        )
      }
    }



  })
