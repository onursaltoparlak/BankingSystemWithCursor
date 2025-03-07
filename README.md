# Bankacılık Uygulaması - Clean Architecture & CQRS

Bu proje, modern yazılım geliştirme tekniklerini yapay zeka araçları (Cursor ve kısmen CoPilot) kullanarak geliştirilmiş, profesyonel bir bankacılık uygulamasıdır. Clean Architecture, CQRS, DDD ve güvenli kimlik doğrulama gibi ileri seviye yazılım mimarileri kullanılmıştır.

## 🚀 Proje Özellikleri
- **Clean Architecture**
  - Domain-Driven Design prensipleri
  - Katmanlı mimari yapılandırması
  - Core, Domain, Application ve Web API katmanları
  - Bağımlılıkların yönetimi ve Dependency Injection
- **CQRS (Command Query Responsibility Segregation)**
  - Command ve Query ayrımı
  - MediatR pattern kullanımı
  - Request/Response modelleri
  - Validation pipeline
  - Exception handling
- **Nesne Modellemesi ve İlişkiler**
  - Entity inheritance (User -> ApplicationUser -> Customer -> IndividualCustomer/CorporateCustomer)
  - Fluent API ile ilişki konfigürasyonları
  - Entity Framework Core optimizasyonları
- **Güvenlik ve Kimlik Doğrulama**
  - JWT (JSON Web Token) implementasyonu
  - Secure password storage
  - Role-based authorization
  - Token validation ve refresh mekanizmaları
- **Veritabanı Yönetimi**
  - Code-First yaklaşımı
  - Repository pattern
- **Best Practices**
  - SOLID prensipleri uygulaması
  - Clean Code yaklaşımı
  - Design pattern'ler
  - Logging mekanizmaları

## 🛠 Kullanılan Teknolojiler
- **.NET 9 Framework**
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **MediatR**
- **FluentValidation**
- **JWT Bearer Authentication**

## 🎯 Hedef Kitle
- Orta-İleri seviye .NET geliştiricileri
- Mimari tasarım konusunda kendini geliştirmek isteyenler
- Enterprise uygulamalar geliştiren yazılımcılar
- Clean Architecture ve CQRS konularında pratik yapmak isteyenler

## 📌 Kurulum
1. Bu repoyu klonlayın:
   ```bash
   git clone https://github.com/onursaltoparlak/BankingSystemWithCursor.git
   ```
2. Gerekli bağımlılıkları yükleyin:
   ```bash
   dotnet restore
   ```
3. Veritabanını migrate edin:
   ```bash
   dotnet ef database update
   ```
4. Projeyi çalıştırın:
   ```bash
   dotnet run
   ```

## 🎓 Öğrenecekleriniz
- Yapay Zeka ile Kurumsal Proje Geliştirme
- SOLID Yazılım Geliştirme Teknikleri
- Clean Architecture Uygulama
- CQRS Kullanımı
- Doğru Prompting Teknikleri
- Üst Düzey Programlama Yetenekleri

---
Bu repo, profesyonel yazılım geliştirme süreçlerini öğrenmek ve pratik yapmak isteyen geliştiriciler için kapsamlı bir rehber niteliğindedir. Herhangi bir katkıda bulunmak isterseniz, pull request göndermekten çekinmeyin! 🚀


