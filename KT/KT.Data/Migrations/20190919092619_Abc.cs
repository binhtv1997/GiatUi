using Microsoft.EntityFrameworkCore.Migrations;

namespace KT.Data.Migrations
{
    public partial class Abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Accounts_AccountId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippers_ShipperDeliverId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippers_ShipperTakeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Slots_SlotDeliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Slots_SlotTakeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Services_ServiceId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Stores_StoreId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippers_Accounts_AccountId",
                table: "Shippers");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Accounts_AccountId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shippers",
                table: "Shippers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataViews",
                table: "DataViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Store");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "Slot");

            migrationBuilder.RenameTable(
                name: "Shippers",
                newName: "Shipper");

            migrationBuilder.RenameTable(
                name: "ServiceTypes",
                newName: "ServiceType");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "OrderServices",
                newName: "OrderService");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "DataViews",
                newName: "DataView");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admin");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_AccountId",
                table: "Store",
                newName: "IX_Store_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Shippers_AccountId",
                table: "Shipper",
                newName: "IX_Shipper_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_StoreId",
                table: "Service",
                newName: "IX_Service_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Service",
                newName: "IX_Service_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_ServiceId",
                table: "OrderService",
                newName: "IX_OrderService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServices_OrderId",
                table: "OrderService",
                newName: "IX_OrderService_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SlotTakeId",
                table: "Order",
                newName: "IX_Order_SlotTakeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SlotDeliveryId",
                table: "Order",
                newName: "IX_Order_SlotDeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipperTakeId",
                table: "Order",
                newName: "IX_Order_ShipperTakeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipperDeliverId",
                table: "Order",
                newName: "IX_Order_ShipperDeliverId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AccountId",
                table: "Customer",
                newName: "IX_Customer_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_AccountId",
                table: "Admin",
                newName: "IX_Admin_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                table: "Slot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipper",
                table: "Shipper",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderService",
                table: "OrderService",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataView",
                table: "DataView",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Account_AccountId",
                table: "Admin",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Account_AccountId",
                table: "Customer",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shipper_ShipperDeliverId",
                table: "Order",
                column: "ShipperDeliverId",
                principalTable: "Shipper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shipper_ShipperTakeId",
                table: "Order",
                column: "ShipperTakeId",
                principalTable: "Shipper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Slot_SlotDeliveryId",
                table: "Order",
                column: "SlotDeliveryId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Slot_SlotTakeId",
                table: "Order",
                column: "SlotTakeId",
                principalTable: "Slot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderService_Order_OrderId",
                table: "OrderService",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderService_Service_ServiceId",
                table: "OrderService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceType_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Store_StoreId",
                table: "Service",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipper_Account_AccountId",
                table: "Shipper",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Account_AccountId",
                table: "Store",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Account_AccountId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Account_AccountId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shipper_ShipperDeliverId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shipper_ShipperTakeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Slot_SlotDeliveryId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Slot_SlotTakeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderService_Order_OrderId",
                table: "OrderService");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderService_Service_ServiceId",
                table: "OrderService");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceType_ServiceTypeId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Store_StoreId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipper_Account_AccountId",
                table: "Shipper");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Account_AccountId",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipper",
                table: "Shipper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderService",
                table: "OrderService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataView",
                table: "DataView");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "Slot",
                newName: "Slots");

            migrationBuilder.RenameTable(
                name: "Shipper",
                newName: "Shippers");

            migrationBuilder.RenameTable(
                name: "ServiceType",
                newName: "ServiceTypes");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "OrderService",
                newName: "OrderServices");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "DataView",
                newName: "DataViews");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Admins");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Store_AccountId",
                table: "Stores",
                newName: "IX_Stores_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipper_AccountId",
                table: "Shippers",
                newName: "IX_Shippers_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_StoreId",
                table: "Services",
                newName: "IX_Services_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Services",
                newName: "IX_Services_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderService_ServiceId",
                table: "OrderServices",
                newName: "IX_OrderServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderService_OrderId",
                table: "OrderServices",
                newName: "IX_OrderServices_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_SlotTakeId",
                table: "Orders",
                newName: "IX_Orders_SlotTakeId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_SlotDeliveryId",
                table: "Orders",
                newName: "IX_Orders_SlotDeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ShipperTakeId",
                table: "Orders",
                newName: "IX_Orders_ShipperTakeId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ShipperDeliverId",
                table: "Orders",
                newName: "IX_Orders_ShipperDeliverId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_AccountId",
                table: "Customers",
                newName: "IX_Customers_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_AccountId",
                table: "Admins",
                newName: "IX_Admins_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shippers",
                table: "Shippers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderServices",
                table: "OrderServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataViews",
                table: "DataViews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Accounts_AccountId",
                table: "Admins",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippers_ShipperDeliverId",
                table: "Orders",
                column: "ShipperDeliverId",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippers_ShipperTakeId",
                table: "Orders",
                column: "ShipperTakeId",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Slots_SlotDeliveryId",
                table: "Orders",
                column: "SlotDeliveryId",
                principalTable: "Slots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Slots_SlotTakeId",
                table: "Orders",
                column: "SlotTakeId",
                principalTable: "Slots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Orders_OrderId",
                table: "OrderServices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Services_ServiceId",
                table: "OrderServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Stores_StoreId",
                table: "Services",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippers_Accounts_AccountId",
                table: "Shippers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Accounts_AccountId",
                table: "Stores",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
