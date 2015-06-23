angular.module('cheping', [
    'ionic',
    'ngCordova',
    'cheping.filters',
    'cheping.interceptors',
    'cheping.services',
    'cheping.services.user',
    'cheping.services.case',
    'cheping.case',
    'cheping.daiban',
    'cheping.new',
    'cheping.user',
    'cheping.transcations'
])
    .constant('URLS', {
        USER: {
            GETINFO: 'http://cheping.yuyidev.com:80/api/Users',
            SIGNIN: 'http://cheping.yuyidev.com:80/api/Users/Login'
        },
        CASE: {
            GETCASELIST: 'http://cheping.yuyidev.com:80/api/Case/List',
            GETVEHICLEINFO: 'http://cheping.yuyidev.com:80/api/Case/VehicleInfo',
            GETTODOS: 'http://cheping.yuyidev.com:80/api/Case/Todos',
            GETWARNINGS: 'http://cheping.yuyidev.com:80/api/Case/Warnings',
            REJECT: 'http://cheping.yuyidev.com:80/api/Case/Reject',
            ADDYANCHEINFO: 'http://cheping.yuyidev.com:80/api/Case/AddYancheInfo',
            REVIEWCASE: 'http://cheping.yuyidev.com:80/api/Case/ReviewCase',
            ACCEPTPRICE: 'http://cheping.yuyidev.com:80/api/Case/AcceptPrice',
            APPLYPAYMENT: 'http://cheping.yuyidev.com:80/api/Case/ApplyPayment',
            APPROVEPAYMENT: 'http://cheping.yuyidev.com:80/api/Case/ApprovePayment',
            PURCHASE: 'http://cheping.yuyidev.com:80/api/Case/Purchase',
            REJECTIONCONFIRM: 'http://cheping.yuyidev.com:80/api/Case/RejectionConfirm',
            ADDCASE: 'http://cheping.yuyidev.com:80/api/Case/AddCase',
            ADDPHOTO: 'http://cheping.yuyidev.com:80/api/Photos/Create',
            TRANSCATIONS: 'http://cheping.yuyidev.com:80/api/TranscationRecord/Case/'
        },
        CONFIG: {
            BRANDS: 'http://cheping.yuyidev.com:80/api/Models/Brands',
            SERIES: 'http://cheping.yuyidev.com:80/api/Models/Series',
            MODELINGS: 'http://cheping.yuyidev.com:80/api/Models/Modelings'

        }
    })
    .config(function($ionicConfigProvider) {
        $ionicConfigProvider.views.transition('ios');
        $ionicConfigProvider.tabs.position('bottom');
        $ionicConfigProvider.backButton.text('').icon('ion-ios-arrow-back');
    })
    .config(function($httpProvider) {
        //$httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push('globalInterceptor');
        $httpProvider.interceptors.push('loadingInterceptor');
    })
    .config(function($compileProvider) {
        $compileProvider.imgSrcSanitizationWhitelist(/^\s*(https?|file|blob|cdvfile):|data:image\//);
    })
    .config(function($stateProvider, $urlRouterProvider) {
        $stateProvider.state('cheping', {
            url: "",
            views: {
                '@': {
                    controller: 'MainCtrl as ctrl',
                    templateUrl: 'app/index.tpl.html'
                }
            }
        });

        $urlRouterProvider.otherwise('/daiban');
    })
    .run(function($ionicPlatform) {
        $ionicPlatform.ready(function() {
            if (window.cordova && window.cordova.plugins.Keyboard) {
                cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
                cordova.plugins.Keyboard.disableScroll(true);
            }
            if (window.StatusBar) {
                StatusBar.styleDefault();
            }
        });
    })
    .run(function($rootScope, $ionicLoading) {
        $rootScope.$on('loading:show', function() {
            $ionicLoading.show({
                template: '<ion-spinner icon="spiral" class="spinner-energized"></ion-spinner>'
            });
        });

        $rootScope.$on('loading:hide', function() {
            $ionicLoading.hide();
        });

        $rootScope.$on('http:requestError', function() {
            $ionicLoading.hide();
            $ionicLoading.show({
                template: '请求失败',
                duration: 3000
            });
        });

        $rootScope.$on('http:responseError-500', function() {
            $ionicLoading.hide();
            $ionicLoading.show({
                template: '请稍后再试',
                duration: 3000
            });
        });
    })
    .controller('MainCtrl', function($scope, $state, UserService, AuthService, UtilityService) {
        var ctrl = this;

        ctrl.showNewTab = false;
        ctrl.showWarningTab = false;
        ctrl.showTab = false;

        ctrl.reload = function() {
            UserService.getUserInfo()
                .then(function(result) {
                    if (result.jobTitle === 40 || result.jobTitle === 50) {
                        ctrl.showWarningTab = true;
                        ctrl.showNewTab = false;
                        ctrl.showTab = true;
                    } else if (result.jobTitle === 10) {
                        ctrl.showWarningTab = false;
                        ctrl.showNewTab = true;
                        ctrl.showTab = true;
                    } else {
                        AuthService.clearToken();
                        UtilityService.showAlert('用户权限错误');
                        $state.go('cheping.user-login');
                    }
                });
        };

        $scope.$on('$ionicView.enter', function() {
            ctrl.reload();
        });
    });

