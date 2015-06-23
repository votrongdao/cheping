angular.module('cheping.services.case', [])
    .service('CaseService', function($http, URLS, AuthService, CacheService) {
        var service = this;

        service.getCase = function(caseId) {
            var url = URLS.CASE.GETVEHICLEINFO + '?' + 'caseId=' + caseId;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.getCases = function(pageIndex, carType) {
            var url = URLS.CASE.GETCASELIST + '?' + 'pageIndex=' + pageIndex + '&pageSize=10&carType=' + carType;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.getTodos = function() {
            var url = URLS.CASE.GETTODOS;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });
        };

        service.getWarnings = function() {
            var url = URLS.CASE.GETWARNINGS;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });
        };

        service.getTranscations = function(caseId) {
            var url = URLS.CASE.TRANSCATIONS + caseId;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });
        };

        service.getVehicleInfo = function(caseId) {
            var url = URLS.CASE.GETVEHICLEINFO + '?' + 'caseId=' + caseId;

            return $http.get(url, {
                cache: CacheService.get('caseCache')
            }).then(function(result) {
                return result.data;
            });

        };

        service.reject = function(caseId, reason) {
            var url = URLS.CASE.REJECT + '?' + 'caseId=' + caseId + '&message=' + reason;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.acceptPrice = function(caseId, price) {
            var url = URLS.CASE.ACCEPTPRICE + '?' + 'caseId=' + caseId + '&purchasePrice=' + price;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.reviewCase = function(caseId, price) {
            var url = URLS.CASE.REVIEWCASE + '?' + 'caseId=' + caseId + '&purchasePrice=' + price;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.applyPayment = function(caseId) {
            var url = URLS.CASE.APPLYPAYMENT + '?' + 'caseId=' + caseId;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.approvePayment = function(caseId) {
            var url = URLS.CASE.APPROVEPAYMENT + '?' + 'caseId=' + caseId;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.rejectionConfirm = function(caseId) {
            var url = URLS.CASE.REJECTIONCONFIRM + '?' + 'caseId=' + caseId;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.purchase = function(caseId) {
            var url = URLS.CASE.PURCHASE + '?' + 'caseId=' + caseId;

            return $http.get(url).then(function(result) {
                return result.data;
            });
        };

        service.addYancheInfo = function(data) {
            var url = URLS.CASE.ADDYANCHEINFO;

            return $http.post(url, data).then(function(result) {
                return result.data;
            });
        };
    });
