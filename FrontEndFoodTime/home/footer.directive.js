angular.module('app')
.directive('cwiFooter', function (authService, $rootScope) {

  return {
    restrict: 'E',
    scope: {},    
    templateUrl: '../home/footer.directive.html'
  }

});