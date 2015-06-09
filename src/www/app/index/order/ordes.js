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
    })
    .controller('OrdersCtrl', function(ChepingOrderService) {
        var ordersCtrl = this;
        ordersCtrl.orders = ChepingOrderService.getOrders();

    });
