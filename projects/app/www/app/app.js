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
    'cheping.new'
])
    .constant('URLS', {
        USER: {
            GETINFO: 'http://cheping.chinacloudsites.cn:80/api/Users',
            SIGNIN: 'http://cheping.chinacloudsites.cn:80/api/Users/Login'
        },
        CASE: {
            GETCASELIST: 'http://cheping.chinacloudsites.cn:80/api/Case/List',
            GETVEHICLEINFO: 'http://cheping.chinacloudsites.cn:80/api/Case/VehicleInfo',
            GETTODOS: 'http://cheping.chinacloudsites.cn:80/api/Case/Todos',
            GETWARNINGS: 'http://cheping.chinacloudsites.cn:80/api/Case/Warnings',
            REJECT: 'http://cheping.chinacloudsites.cn:80/api/Case/Reject',
            ADDYANCHEINFO: 'http://cheping.chinacloudsites.cn:80/api/Case/AddYancheInfo',
            REVIEWCASE: 'http://cheping.chinacloudsites.cn:80/api/Case/ReviewCase',
            ACCEPTPRICE: 'http://cheping.chinacloudsites.cn:80/api/Case/AcceptPrice',
            APPLYPAYMENT: 'http://cheping.chinacloudsites.cn:80/api/Case/ApplyPayment',
            APPROVEPAYMENT: 'http://cheping.chinacloudsites.cn:80/api/Case/ApprovePayment',
            PURCHASE: 'http://cheping.chinacloudsites.cn:80/api/Case/Purchase',
            REJECTIONCONFIRM: 'http://cheping.chinacloudsites.cn:80/api/Case/RejectionConfirm'
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
    .controller('MainCtrl', function($state, UserService, UtilityService) {
        var ctrl = this;

        ctrl.showNewTab = false;
        ctrl.showWarningTab = false;

        UserService.getUserInfo()
            .then(function(result) {
                if (result.jobTitle === 40 || result.jobTitle === 50) {
                    ctrl.showNewTab = true;
                } else if (result.jobTitle === 10) {
                    ctrl.showNewTab = true;
                } else {
                    UtilityService.showAlert('请先登录');
                    $state.go('cheping.user-login');
                }
            });
    });

