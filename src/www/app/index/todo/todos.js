angular.module('cheping.index.todos', [])
  .config(function($stateProvider) {
    $stateProvider
      .state('cheping.index.todos', {
        url: '/todos',
        views: {
          'index.todos': {
            controller: 'TodosCtrl as todosCtrl',
            templateUrl: 'app/index/todo/todo-index.tpl.html'
          }
        }
      })
      .state('cheping.index.todoDetail', {
        url: '/todos/detail/{orderNo}',
        views: {
          'index.todos': {
            controller: 'TodoDetailCtrl as todoDetailCtrl',
            templateUrl: 'app/index/todo/todo-detail.tpl.html'
          }
        }
      })
  })
  .controller('TodosCtrl', function(ChepingOrderService) {
    var todosCtrl = this;
    todosCtrl.orders = ChepingOrderService.getOrders();

  })

  .controller('TodoDetailCtrl', function($scope, $state, $stateParams, $ionicPopup, ChepingOrderService) {
    var todoDetailCtrl = this;
    todoDetailCtrl.order = ChepingOrderService.getOrder($stateParams.orderNo);

    todoDetailCtrl.goBack = function() {
      $state.go('cheping.index.todos');
    };

    todoDetailCtrl.showPopup = function() {
      $scope.data={};
      var myPopup = $ionicPopup.show({
        template: '<input type="text" ng-model="data.reason">',
        title: '请输入验车失败原因',
        scope: $scope,
        buttons: [
          {text: '取消'},
          {
            text: '<b>确认</b>',
            type: 'button-positive',
            onTap: function(e) {
              if (!$scope.data.reason) {
                //don't allow the user to close unless he enters wifi password
                e.preventDefault();
              } else {
                return $scope.data.reason;
              }
            }
          }
        ]
      });

      myPopup.then(function(res) {
        console.log('Tapped!', res);
      });

      //  $timeout(function() {
      //    myPopup.close(); //close the popup after 3 seconds for some reason
      //}, 3000);

    };
  });


//
//$state.showPopup = function() {
//  $state.data = {}
//
//  // An elaborate, custom popup
//  var myPopup = $ionicPopup.show({
//    template: '<input type="password" ng-model="data.wifi">',
//    title: 'Enter Wi-Fi Password',
//    subTitle: 'Please use normal things',
//    scope: $scope,
//    buttons: [
//      { text: 'Cancel' },
//      {
//        text: '<b>Save</b>',
//        type: 'button-positive',
//        onTap: function(e) {
//          if (!$scope.data.wifi) {
//            //don't allow the user to close unless he enters wifi password
//            e.preventDefault();
//          } else {
//            return $scope.data.wifi;
//          }
//        }
//      }
//    ]
//  });
//  myPopup.then(function(res) {
//    console.log('Tapped!', res);
//  });
//  $timeout(function() {
//    myPopup.close(); //close the popup after 3 seconds for some reason
//  }, 3000);
//};
