
cd ~/Dropbox/Documents/VisualStudio

mkdir NutritionTrackerRazorPages

cd NutritionTrackerRazorPages

# ----------------------------------------------------------------------

git init

# ----------------------------------------------------------------------

dotnet new gitignore

# ----------------------------------------------------------------------

dotnet new webapp

# ----------------------------------------------------------------------

dotnet add package Microsoft.EntityFrameworkCore.SQLite -v 5.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 5.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.0-*
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 5.0.0-*
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 5.0.0-*
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore -v 5.0.0-*  

# ----------------------------------------------------------------------

dotnet tool install --global dotnet-aspnet-codegenerator

# ----------------------------------------------------------------------

dotnet aspnet-codegenerator razorpage `
    --model FoodCategory `
    --dataContext NutritionTrackerRazorPages.Data.NutritionTrackerContext `
    --useDefaultLayout `
    --relativeFolderPath Pages\FoodCategories `
    --referenceScriptLibraries `
    --useSqlite

# ----------------------------------------------------------------------
    
dotnet tool install --global dotnet-ef

dotnet ef database drop --force

# ----------------------------------------------------------------------

dotnet ef migrations add InitialCreate

dotnet ef database update

# ----------------------------------------------------------------------

dotnet aspnet-codegenerator razorpage `
    --model FoodItem `
    --dataContext NutritionTrackerRazorPages.Data.NutritionTrackerContext `
    --useDefaultLayout `
    --relativeFolderPath Pages\FoodItems `
    --referenceScriptLibraries `
    --useSqlite

# ----------------------------------------------------------------------

dotnet ef migrations add FoodItem
dotnet ef database update
