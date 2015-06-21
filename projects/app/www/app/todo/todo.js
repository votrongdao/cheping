angular.module('cheping.todos', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.todos', {
                url: '/cases/list/{:carType}',
                views: {
                    'todos': {
                        controller: 'TodosCtrl as todos',
                        templateUrl: 'app/todo/index.tpl.html'
                    }
                }
            })
    })
    .controller('TodosCtrl', function($state, UserService, CaseService, UtilityService) {
        var todos = this;
        var user = UserService.getUserInfo();

        todos.items = [];

        todos.getTodos = function() {
            CaseService.getTodos()
                .then(function(result) {
                    _.forEach(result.items, function(i) {
                        todos.items.push(i);
                    });
                })
        };

        todos.getTodos();
    });