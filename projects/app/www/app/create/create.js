angular.module('cheping.new', [
    'cheping.services.user'
])
    .config(function($stateProvider) {
        $stateProvider
            .state('cheping.new', {
                url: '/new',
                views: {
                    'new': {
                        controller: 'CaseCtrl as ctrl',
                        templateUrl: 'app/create/index.tpl.html'
                    }
                }
            })
    })
    .controller('CaseCtrl', function(UserService) {
        UserService.getUserInfo();
    });