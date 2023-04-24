/**
 * This view is an example list of people.
 */
Ext.define('ClientApp.view.loanlist.LoansGrid', {
    extend: 'Ext.grid.Panel',
    xtype: 'loansgrid',

    requires: [
        'ClientApp.store.Loans',
        'ClientApp.view.loanlist.LoansGridController'
    ],

    // title: 'Loans',
    controller: 'loansgrid-loansgrid',

    store: {
        type: 'loans'
    },

    columns: [
        { text: 'Id', dataIndex: 'id', },
        { text: 'Type', dataIndex: 'type', },
        { text: 'Amount', dataIndex: 'amount', },
        { text: 'Currency', dataIndex: 'currency', },
        { text: 'Loan Years', dataIndex: 'loanYears', },
        { text: 'Loan Months', dataIndex: 'loanMonths', },
        { text: 'Loan Days', dataIndex: 'loanDays', },
        { text: 'Status', dataIndex: 'status', },
        {
            xtype: 'widgetcolumn',
            text: 'Edit',
            widget: {
                xtype: 'button',
                text: 'Edit',
                listeners: {
                    click: 'onButtonEditClick'
                }
            }
        },
        {
            xtype: 'widgetcolumn',
            text: 'Approve',
            widget: {
                xtype: 'button',
                text: 'Approve',
                handler: function(btn) {
                    var rec = btn.getWidgetRecord();

                    var id = rec.get('id');

                    Ext.Ajax.request({
                        url: 'https://localhost:7000/api/Loan/AcceptLoan/' + id,
                        method: 'PUT',
                        headers: {
                            "Authorization": 'Bearer ' + localStorage.getItem('token')
                        },
                        success: function(response, opts) {
                            // handle success response
                            window.location.reload();
                        },
                        failure: function(response, opts) {
                            let resp = JSON.parse(response.responseText);
                            let errors = resp.message.errors;
                            let msg = Object.keys(errors)[0]
                            Ext.Msg.alert('Error', msg);
                        }
                    });
                }
            }
        },
        {
            xtype: 'widgetcolumn',
            text: 'Decline',
            widget: {
                xtype: 'button',
                text: 'Decline',
                handler: function(btn) {
                    var rec = btn.getWidgetRecord();

                    var id = rec.get('id');

                    Ext.Ajax.request({
                        url: 'https://localhost:7000/api/Loan/DeclineLoan/' + id,
                        method: 'PUT',
                        headers: {
                            "Authorization": 'Bearer ' + localStorage.getItem('token')
                        },
                        success: function(response, opts) {
                            // handle success response
                            window.location.reload();
                        },
                        failure: function(response, opts) {
                            let resp = JSON.parse(response.responseText);
                            let errors = resp.message.errors;
                            let msg = Object.keys(errors)[0]
                            Ext.Msg.alert('Error', msg);
                        }
                    });
                }
            }
        },
        {
            xtype: 'widgetcolumn',
            text: 'Delete',
            widget: {
                xtype: 'button',
                text: 'Delete',
                handler: function(btn) {
                    var rec = btn.getWidgetRecord();

                    var id = rec.get('id');

                    Ext.Ajax.request({
                        url: 'https://localhost:7000/api/Loan/DeleteLoan/' + id,
                        method: 'DELETE',
                        headers: {
                            "Authorization": 'Bearer ' + localStorage.getItem('token')
                        },
                        success: function(response, opts) {
                            // handle success response
                            window.location.reload();
                        },
                        failure: function(response, opts) {
                            let resp = JSON.parse(response.responseText);
                            let errors = resp.message.errors;
                            let msg = Object.keys(errors)[0]
                            Ext.Msg.alert('Error', msg);
                        }
                    });
                }
            }
        }
    ]//,

    // listeners: {
    //     select: 'onItemSelected'
    // }
});
