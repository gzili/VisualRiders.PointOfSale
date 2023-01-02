﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisualRiders.PointOfSale.Project;

#nullable disable

namespace VisualRiders.PointOfSale.Project.Migrations
{
    [DbContext(typeof(PointOfSaleContext))]
    partial class PointOfSaleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.12");

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.BusinessEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BusinessEntities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Test street 1, Test town, Test country",
                            Code = "00000",
                            Description = "This is the default business that cannot be deleted.",
                            Name = "Default Business"
                        });
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaxId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("TaxId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientLoyaltyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("ClientLoyaltyId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ClientLoyalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LoyaltyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LoyaltyId");

                    b.ToTable("ClientLoyalties");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.DiscountItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscountId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DiscountSize")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ServiceId");

                    b.ToTable("DiscountItems");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastRefill")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ItemSelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("AdditionalPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemSelections");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ItemSelectionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemSelectionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemSelectionId");

                    b.ToTable("ItemSelectionValues");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Loyalty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DiscountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("DiscountId");

                    b.ToTable("Loyalties");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TaxTotal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Tips")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Change")
                        .HasColumnType("TEXT");

                    b.Property<int>("Method")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MeasUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Returnable")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TaxId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TaxId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ProductSelector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ItemSelectionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemSelectionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSelectors");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReservationStart")
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ReturnedItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ReturnedPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("StaffMemberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderItemId", "PaymentId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("ReturnedItems");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Duration")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaxId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TaxId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ServiceSelector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ItemSelectionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemSelectionId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceSelectors");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StaffMemberId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.StaffMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BankAcc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Occupancy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SocSecNum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("StartedFrom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.ToTable("StaffMembers");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Percentage")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BusinessEntityId");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Category", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Tax", "Tax")
                        .WithMany()
                        .HasForeignKey("TaxId");

                    b.Navigation("BusinessEntity");

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Client", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.ClientLoyalty", "ClientLoyalty")
                        .WithMany()
                        .HasForeignKey("ClientLoyaltyId");

                    b.Navigation("BusinessEntity");

                    b.Navigation("ClientLoyalty");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ClientLoyalty", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Loyalty", "Loyalty")
                        .WithMany()
                        .HasForeignKey("LoyaltyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loyalty");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Discount", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessEntity");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.DiscountItem", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Discount");

                    b.Navigation("Product");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Inventory", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessEntity");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ItemSelectionValue", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.ItemSelection", "ItemSelection")
                        .WithMany("ItemSelectionValues")
                        .HasForeignKey("ItemSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemSelection");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Loyalty", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessEntity");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Order", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("BusinessEntity");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.OrderItem", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Payment", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Product", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Tax", "Tax")
                        .WithMany()
                        .HasForeignKey("TaxId");

                    b.Navigation("BusinessEntity");

                    b.Navigation("Category");

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ProductSelector", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.ItemSelection", "ItemSelection")
                        .WithMany("ProductSelectors")
                        .HasForeignKey("ItemSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemSelection");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Reservation", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ReturnedItem", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.OrderItem", "OrderItem")
                        .WithMany()
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.StaffMember", "StaffMember")
                        .WithMany()
                        .HasForeignKey("StaffMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderItem");

                    b.Navigation("Payment");

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Service", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Tax", "Tax")
                        .WithMany()
                        .HasForeignKey("TaxId");

                    b.Navigation("BusinessEntity");

                    b.Navigation("Category");

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ServiceSelector", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.ItemSelection", "ItemSelection")
                        .WithMany("ServiceSelectors")
                        .HasForeignKey("ItemSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisualRiders.PointOfSale.Project.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemSelection");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Shift", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.StaffMember", "StaffMember")
                        .WithMany()
                        .HasForeignKey("StaffMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.StaffMember", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessEntity");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Tax", b =>
                {
                    b.HasOne("VisualRiders.PointOfSale.Project.Models.BusinessEntity", "BusinessEntity")
                        .WithMany()
                        .HasForeignKey("BusinessEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessEntity");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.ItemSelection", b =>
                {
                    b.Navigation("ItemSelectionValues");

                    b.Navigation("ProductSelectors");

                    b.Navigation("ServiceSelectors");
                });

            modelBuilder.Entity("VisualRiders.PointOfSale.Project.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
