/**
 * The main application class. An instance of this class is created by app.js when it
 * calls Ext.application(). This is the ideal place to handle application launch and
 * initialization details.
 */
Ext.define('ClientApp.Application', {
    extend: 'Ext.app.Application',

    name: 'ClientApp',

    quickTips: false,
    platformConfig: {
        desktop: {
            quickTips: true
        }
    },

    routes: {
        'edit/:id': {
            action: 'editloan',
            before: 'onBeforeEditLoan',
            conditions: {
                ':id': '([0-9]+)'
            }
        }
    },

    launch: function() {
        let token = localStorage.getItem('token');
        if (token) {
            Ext.create({
                xtype: 'loanlist'
            });
        } else {
            Ext.create({
                xtype: 'login'
            });
        }
    },

    onAppUpdate: function () {
        Ext.Msg.confirm('Application Update', 'This application has an update, reload?',
            function (choice) {
                if (choice === 'yes') {
                    window.location.reload();
                }
            }
        );
    }
});
