angular.module('cheping.index.orders', [
])
    .config(function ($stateProvider) {
        $stateProvider
            .state('cheping.index.orders', {
                url: '/orders',
                views: {
                    'index.orders': {
                        controller: 'OrdersCtrl as ordersCtrl',
                        templateUrl: 'app/index/order/order-index.tpl.html'
                    }
                }
            })
          .state('cheping.index.orderList', {
                url: '/orders/list',
                views: {
                    'index.orders': {
                      controller: 'OrderListCtrl as orderListCtrl',
                      templateUrl: 'app/index/order/order-list.tpl.html'
                    }
                }
          })
          .state('cheping.index.orderListDetail', {
                url: '/orders/list/detail',
                views: {
                    'index.orders': {
                      controller: 'OrderListDetailCtrl as orderListDetailCtrl',
                      templateUrl:'app/index/order/order-detail.tpl.html'
                    }
                }
          });
          //.state('cheping.index.orderList-detail', {
          //  url: '/orders/list/detail',
          //  views: {
          //    'index.orders': {
          //      controller: 'OrderDetailCtrl as orderDetailCtrl',
          //      templateUrl: 'app/index/order/order-detail.tpl.html'
          //    }
          //  }
          //})
    })
    .controller('OrdersCtrl', function(ChepingOrderService) {
        var ordersCtrl = this;

    })
    .controller('OrderListCtrl', function($state, $stateParams, ChepingOrderService) {
     var orderListCtrl = this;
         orderListCtrl.orderList = ChepingOrderService.getOrders();
         orderListCtrl.goBack = function() {
           $state.go('cheping.index.orders');
         }
  })
     .controller('OrderListDetailCtrl', function($state, $stateParams, ChepingOrderService) {
     var orderListDetailCtrl = this;
         orderListDetailCtrl.order = ChepingOrderService.getOrder($stateParams.orderNo);
         orderListDetailCtrl.goBack = function() {
           $state.go('cheping.index.orderList');
         }
  });

//
//.controller('CreateDetailCtrl', function($state, $stateParams, ChepingOrderService) {
//  var createDetailCtrl = this;
//  var newOrder = ChepingOrderService.getNewOrder();
//
//  newOrder.carType = $stateParams.carType;
//
//  createDetailCtrl.newOrder = newOrder;
//
//  createDetailCtrl.goBack = function(){
//    $state.go('cheping.index.create');
//  };