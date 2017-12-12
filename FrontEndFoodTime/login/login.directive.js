angular.module('app')
.directive('cwiLogin', function (authService, $rootScope) {
    return {
      restrict: 'E',
      scope: {},
      templateUrl: '../login/login.directive.html'
    }

});
