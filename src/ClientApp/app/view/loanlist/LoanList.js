Ext.define('ClientApp.view.loanlist.LoanList',{
    extend: 'Ext.window.Window',
    xtype: 'loanlist',

    requires: [
        'ClientApp.view.loanlist.LoanListController',
        'ClientApp.view.loanlist.LoanListModel'
    ],

    controller: 'loanlist-loanlist',
    viewModel: {
        type: 'loanlist-loanlist'
    },

    title: 'Loan List',
    width: window.screen.width / 1.25,
    height: window.screen.height / 1.5,

    closable: false,
    autoShow: true,

    layout: 'fit',

    items: [{
        xtype: 'loansgrid'
    }],

    buttons: [{
        text: 'Add New',
        listeners: {
            click: 'onButtonNewClick'
        }
    }, {
        text: 'Logout',
        listeners: {
            click: 'onLogoutClick'
        }
    }]
});
