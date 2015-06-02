angular.module('cheping.controllers', [])
  .controller('TodosCtrl', function($scope, Orders) {
    $scope.todos = Orders.todos();
  })
  .controller('OrdersCtrl', function($scope, Orders) {
    $scope.orders = Orders.all();
  })
  .controller('TodoDetailCtrl', function($scope, $stateParams, Orders) {
    $scope.todo = Orders.get($stateParams.orderNo);
  })
  .controller('OrderDetailCtrl', function($scope, $stateParams, Orders) {
    $scope.order = Orders.get($stateParams.orderNo);
  })
  .controller('NewOrderCtrl', function($scope, Orders) {
    $scope.order = Orders.newOrder();
  });
