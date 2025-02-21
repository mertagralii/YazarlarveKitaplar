# 📖 Yazarlar ve Kitaplar Projesi  

Bu proje, **yazarlar ve onların kitaplarını yönetmek** amacıyla geliştirilmiş bir **web uygulamasıdır**. Kullanıcılar, **yazar ve kitap bilgilerini** ekleyebilir, güncelleyebilir ve silebilir. Bu sayede, kitap ve yazar bilgilerini merkezi bir şekilde yönetmek mümkün hale gelir. 🎯 

Bu Projeyi, Acunmedya Akademi 11. Dönem Genişletilmiş Yazılım Uzmanlığı Eğitimi kapsamında uzmanlığa geçiş sürecindeki Kamp Döneminde geliştirdiğim Web uygulamasıdır. 

## ✨ Özellikler  

✅ **Yazar Yönetimi:** Yeni yazar ekleme, mevcut yazar bilgilerini güncelleme ve silme. 📝  
✅ **Kitap Yönetimi:** Kitap ekleme, güncelleme, silme ve yazarlarla ilişkilendirme. 📚  
✅ **Listeleme:** Yazar ve kitapların detaylı şekilde listelenmesi. 🔍  
✅ **Detaylı Bilgi Sayfaları:** Yazarların ve kitapların detaylı bilgilerini içeren özel sayfalar. 🖥  
✅ **Kategori ve Tür Yönetimi:** Kitapları farklı kategorilere ve türlere ayırarak daha iyi organize etme imkanı. 📖  
✅ **Kolay Kullanıcı Arayüzü:** Kullanıcı dostu arayüzü sayesinde hızlı ve kolay kullanım. 💡  

## 🛠 Kullanılan Teknolojiler  

🖥 **ASP.NET Core MVC** – Uygulamanın temel çatısını oluşturur.  
💾 **Entity Framework Core** – Veritabanı işlemleri için kullanılır.  
🗄 **SQLite** – Hafif ve taşınabilir bir veritabanı çözümü.  
🎨 **HTML, CSS, JavaScript** – Kullanıcı arayüzünü oluşturmak için kullanıldı.  
🛠 **Bootstrap** – Responsive ve modern tasarım için kullanıldı.  

## 🚀 Kurulum  

🛑 **Başlamadan önce:** Bilgisayarında **.NET 6 veya daha yeni bir sürümünün** yüklü olduğundan emin ol.  

### 📥 Depoyu Klonlayın  

```bash
 git clone https://github.com/mertagralii/YazarlarveKitaplar.git
 cd YazarlarveKitaplar
```

### 📦 Bağımlılıkları Yükleyin  

```bash
 dotnet restore
```

### 🏗 Veritabanını Güncelleyin  

```bash
 dotnet ef database update
```

### ▶️ Uygulamayı Başlatın  

```bash
 dotnet run
```

## 🗄 Veritabanı Yapısı  

Aşağıda, projenin kullandığı veritabanı şeması ve başlangıç verileri bulunmaktadır:  

```sql
USE [KitaplarveYazarlarDB]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory](
    [MigrationId] [nvarchar](150) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Kitaplar](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [YazarId] [int] NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [Description] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_Kitaplar] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Yazarlar](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](max) NOT NULL,
    [Surname] [nvarchar](max) NOT NULL,
    [Age] [int] NOT NULL,
    CONSTRAINT [PK_Yazarlar] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT [dbo].[Kitaplar] ([Id], [YazarId], [Name], [Description]) VALUES (2, 2, N'Metenin kitabi', N'Metenin yazdığı')
INSERT [dbo].[Kitaplar] ([Id], [YazarId], [Name], [Description]) VALUES (4, 3, N'Keremin kitap', N'Keremin Yazdığı Kitap')
INSERT [dbo].[Kitaplar] ([Id], [YazarId], [Name], [Description]) VALUES (5, 4, N'Canın kitap', N'Canın Yazdığı')
INSERT [dbo].[Kitaplar] ([Id], [YazarId], [Name], [Description]) VALUES (6, 5, N'Faruk kitap', N'Faruğun yazıdğı kitap')
INSERT [dbo].[Kitaplar] ([Id], [YazarId], [Name], [Description]) VALUES (7, 6, N'Mustafa Kitap', N'Mustafanın yazdığı kitap')
INSERT [dbo].[Kitaplar] ([Id], [YazarId], [Name], [Description]) VALUES (8, 1, N'Mertin2 Kitabi', N'Mertin 2. kitabı')
INSERT [dbo].[Kitaplar] ([Id], [YazarId], [Name], [Description]) VALUES (14, 1, N'Test kitabi', N'test kitabi')
GO

INSERT [dbo].[Yazarlar] ([Id], [Name], [Surname], [Age]) VALUES (1, N'Mert', N'Ağralı', 23)
INSERT [dbo].[Yazarlar] ([Id], [Name], [Surname], [Age]) VALUES (2, N'Metehan', N'Demir', 24)
INSERT [dbo].[Yazarlar] ([Id], [Name], [Surname], [Age]) VALUES (3, N'Kerem', N'Çalış', 25)
INSERT [dbo].[Yazarlar] ([Id], [Name], [Surname], [Age]) VALUES (4, N'Can', N'Şahinoğlu', 25)
INSERT [dbo].[Yazarlar] ([Id], [Name], [Surname], [Age]) VALUES (5, N'Faruk', N'Çakal', 22)
INSERT [dbo].[Yazarlar] ([Id], [Name], [Surname], [Age]) VALUES (6, N'Mustafa', N'Sevindi', 21)
GO
```

---

💡 **Katkıda Bulunmak İster Misin?**  
Pull request'ler ve geri bildirimler her zaman memnuniyetle karşılanır! 😊  

📩 **İletişim:** Eğer bir hata fark edersen veya geliştirme önerin varsa, **issue açabilir** veya bana ulaşabilirsin. 🚀  
