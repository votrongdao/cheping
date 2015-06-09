angular.module('cheping.index.todo', [
])
    .config(function ($stateProvider) {
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
    })
    .controller('TodosCtrl', function(ChepingOrderService) {
        var todosCtrl = this;
        todosCtrl.orders = ChepingOrderService.getOrders();

    });
