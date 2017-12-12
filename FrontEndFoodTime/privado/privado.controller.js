angular.module('app').controller('PrivadoController', function ($scope, authService, fotoService) {

  $scope.addFoto = function(){
    var file = document.getElementById('file').files[0];
    var fd = new FormData();
    fd.append('file', file);
    fotoService.addFoto(fd).then(
      function(response){
        console.log("Foto adicionada com sucesso!");
      }, function(response){
      }
    )};  

  

});
