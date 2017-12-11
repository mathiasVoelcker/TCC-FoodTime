angular.module('app').controller('PrivadoController', function ($scope, authService, fotoService) {

  // $scope.auth = authService;

  // $scope.mensagem = {
  //   colaborador: 'Mensagem incrível para o usuário AUTENTICADO',
  //   administrador: 'Mensagem incrível para o usuário ADMINISTRADOR',
  // };

  $scope.addFoto = function(){
    var file = document.getElementById('file').files[0];
    var fd = new FormData();
    fd.append('file', file);
    fotoService.addFoto(fd).then(
      function(response){
        debugger
        console.log(response)
        alert("Foto adicionada com sucesso!")
      }, function(response){
        debugger
        console.log(response)
      }
    )};  

  

});
