Ext.define('ClientApp.store.Loans', {
    extend: 'Ext.data.Store',
    alias: 'store.loans',
    model: 'ClientApp.model.Loans',
    autoLoad: true,
    proxy: {
        type: 'ajax',
        url: 'https://localhost:7000/api/Loan/GetLoans',
        headers: {
            "Authorization": 'Bearer ' + localStorage.getItem('token')
        },
        reader: {
            type: 'json',
            rootProperty: 'message.items',
            totalProperty: 'message.totalCount'
        },
        actionMethods: { read: 'GET' }
    },
    listeners: {
        // render: function(grid) {
        //     grid.getStore().loadRemoteData();
        // }
    }
});
