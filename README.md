# MovieShelter
Bu proje, bir film kütüphanesi uygulamasını yönetmek ve filmlerle ilgili kategori, yayıncı gibi bilgileri takip etmek amacıyla geliştirilmiştir.

## Kullanılan Teknolojiler

- ASP.NET Core: Projede ASP.NET Core kullanılmıştır. Web uygulaması, yapılandırma ve middleware yönetimi için ASP.NET Core kullanılmıştır.

- Dependency Injection: ASP.NET Core'un entegre ettiği dependency injection özelliği kullanılarak bağımlılıklar yönetilmiştir.

- Entity Framework Core: Veritabanı işlemleri için Entity Framework Core kullanılmıştır. Veritabanına bağlantı için SQL Server kullanılmıştır.

- Swagger/OpenAPI: API'lerin belgelenmesi ve test edilmesi amacıyla Swagger/OpenAPI kullanılmıştır.

- Generic Repository Pattern: Projede genel bir repository (depo) kalıbı uygulanmıştır. Bu, veritabanı işlemlerini soyutlamak ve genelleştirmek için yaygın olarak kullanılan bir tasarım desenidir.

- LINQ (Language-Integrated Query): LINQ ifadeleri, sorgulama işlemleri için kullanılmıştır. LINQ, C#'ın dil içi sorgu yetenekleri sağlayan güçlü bir özelliktir.

- Exception Handling: `BusinessException` sınıfı, iş mantığından kaynaklanan özel istisnaları yönetmek için kullanılmıştır.
