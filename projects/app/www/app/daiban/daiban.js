angular.module('cheping.daiban', [
    'cheping.services.user',
    'cheping.services.case'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.daiban', {
                url: '/daiban',
                views: {
                    'daiban': {
                        controller: 'DaibanCtrl as cases',
                        templateUrl: 'app/daiban/index.tpl.html'
                    }
                }
            })
    })
    .controller('DaibanCtrl', function($state, UserService, CaseService, UtilityService) {
        var cases = this;
        var user = UserService.getUserInfo();

        cases.items = [];

        cases.getTodos = function() {
            CaseService.getTodos()
                .then(function(result) {
                    _.forEach(result, function(i) {
                        cases.items.push(i);
                    });
                })
        };

        cases.getTodos();
    });