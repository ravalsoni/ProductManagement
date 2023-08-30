﻿using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using ProductManagement.Authorization;

namespace ProductManagement.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class ProductManagementNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                   // PageNames.Tasks,
                   "TaskList",
                   L ("TaskList"),
                    url: "Tasks",
                    icon: "fa fa-tasks"
  )
                ).AddItem(
                    new MenuItemDefinition(
                   // PageNames.Tasks,
                   "Category",
                    L("CategoryList"),
                    url: "Category",
                    icon: "fa fa-tasks"
  )
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "MultiLevelMenu",
                        L("MultiLevelMenu"),
                        icon: "fas fa-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            "Category",
                    L("Category"),
                    url: "Category",
                    icon: "fa fa-tasks"
                        ).AddItem(
                            new MenuItemDefinition(
                                "CategoryList",
                                 L("Category"),
                    url: "Category/GetAllCategory",
                     icon: "far fa-dot-circle"
                            )
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ProductManagementConsts.LocalizationSourceName);
        }
    }
}