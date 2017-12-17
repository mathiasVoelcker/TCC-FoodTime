angular.module('app').controller('SugerirEstabelecimentoController', function ($scope, $routeParams, $location, authService, estabService, toastr, fotoService, categoriaService, $http) {

  $scope.estabelecimento = { }
  $scope.estabelecimento.Endereco = { }
  $scope.estabelecimento.Fotos = []
  $scope.estabelecimento.idCategorias = []
  $scope.estabelecimento.idFotos = []
  $scope.estabelecimento.IdPreferencias = []
  $scope.estabelecimento.Aprovado = true
  $scope.phoneMask = "(99) 9999-9999";

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
    place.address_components.forEach(function(address_component){
      address_component.types.forEach(function(type){
        switch(type){
          case "route":
          $scope.estabelecimento.Endereco.Rua = address_component.long_name
          break;
          case "street_number":
          $scope.estabelecimento.Endereco.Numero = address_component.long_name
          break;
          case "postal_code":
          $scope.estabelecimento.Endereco.CEP = address_component.long_name
          break;
          case "sublocality":
          $scope.estabelecimento.Endereco.Bairro = address_component.long_name
          break;
          case "administrative_area_level_2":
          $scope.estabelecimento.Endereco.Cidade = address_component.long_name
          break;
          case "administrative_area_level_1":
          $scope.estabelecimento.Endereco.Estado = address_component.long_name
          break;
        }
      })
    })
    if(place.opening_hours != undefined){
      $scope.estabelecimento.HorarioAbertura = new Date(place.opening_hours.periods[0].open.nextDate)
      $scope.estabelecimento.HorarioFechamento = new Date(place.opening_hours.periods[0].close.nextDate)
    }
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
           /* toastr.success('Foto adicionada com sucesso!')*/
          }, function(response){
          }
        )};
        console.log(estabelecimento)
        estabelecimento.Endereco.CEP = estabelecimento.Endereco.CEP.replace(/[^a-zA-Z0-9]/g, '')
        estabelecimento.Telefone = estabelecimento.Telefone.replace(/[^a-zA-Z0-9]/g, '')
        console.log(estabelecimento)
        estabService.criarEstabelecimento(estabelecimento).then(
          function(response){
            toastr.success('Estabelecimento Cadastrado com sucesso!')
            console.log(response)
            redirecionar();
          }
        )
      }
    }



  })
