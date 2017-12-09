angular.module('app').controller('LoginController', function ($scope, toastr, authService, $location, $http) {

  function redirecionar(promise) {
    promise.then(function () {
        $location.path('/home/');
    })
}

  $scope.login = function (usuario) {
    let promise;

    promise = authService.loginTemp(usuario)
      .then(
        function () {
          toastr.success('Login com sucesso!')
          redirecionar(promise);

        },
        function (error) {
          toastr.error('Erro no Login!')
        });
  };

});
