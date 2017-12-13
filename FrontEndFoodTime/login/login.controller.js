angular.module('app').controller('LoginController', function ($scope, toastr, authService, $location, $http) {

  function redirecionar(promise) {
    promise.then(function () {
      $location.path('/home/');
    })
  }

  $scope.login = function (usuario) {
    let promise;

    promise = authService.login(usuario)
      .then(
      function (response) {
        toastr.success('Login com sucesso!')
        redirecionar(promise);
      },
      function (response) {
        toastr.error('Erro no Login!')
      });
  };

});


