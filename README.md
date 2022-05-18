# Chương 1: Mở đầu


### 1. **Giới thiệu ứng dụng**
### 2. **Yêu cầu ứng dụng (ngôn ngữ viết code, các thư viện hỗ trợ để chạy demo, cài đặt database,...)**

# Chương 2: Cơ sở lý thuyết




### 1. **Singleton**


  1.1 *Singleton pattern là gì ?*
  
  
  ![image](https://user-images.githubusercontent.com/65171477/168466983-cdfdcca7-8f26-41ee-a2dd-0584434eb615.png)



Singleton Pattern là một design pattern trong số 5 design pattern thuộc nhóm Creational Design Pattern. 

Singleton Pattern là một design pattern:
- 	Đảm bảo một class chỉ có duy nhất một instance.
- 	Do instance có khả năng sử dụng trong suốt chương trình, nên Singleton cũng cung cấp một điểm truy cập toàn tục đến instance đó.

1.2 *Tại sao cần dùng Singleton Pattern?*
- Hầu hết các đối tượng trong một ứng dụng đều chịu trách nhiệm cho công việc của chúng và truy xuất dữ liệu tự lưu trữ (self-contained data) và các tham chiếu trong phạm vi được đưa ra của chúng. Tuy nhiên, có nhiều đối tượng có thêm những nhiệm vụ và có ảnh hưởng rộng hơn, chẳng hạn như quản lý các nguồn tài nguyên bị giới hạn hoặc theo dõi toàn bộ trạng thái của hệ thống. Ví dụ có thể có rất nhiều máy in trong hệ thống nhưng chỉ có thể tồn tại duy nhất một Sprinter Spooler (Phần quản lý máy in) thì lúc này cần sử dụng Singleton để có duy nhất một đối tượng Sprinter Spooler được thực hiện.
   ![image](https://user-images.githubusercontent.com/65171477/168466995-5d677e42-f508-4f2b-835f-ec82e7734124.png)

  Khi bạn cần đối tượng thực hiện chức năng cụ thể như viết log cho chương trình thì nó nên được viết thành Singleton. Bất kể tại phần nào của chương trình chỉ có duy nhất một instance, một truy cập đến Logger

1.3 *Cài đặt*

![image](https://user-images.githubusercontent.com/65171477/168467001-7dbd5318-d71e-43cc-890a-a47069a9878b.png)


  Để biến một class thành Singleton, cần đảm bảo rằng:
- Dữ liệu thành viên instance (private và static) là đối tượng duy nhất của lớp Singleton.
- Constructor của lớp Singleton được định nghĩa thành protected hoặc private để người dùng không thể tạo thực thể trực tiếp từ bên ngoài.
- Phương thức getInstance() dùng để khởi tạo đối tượng duy nhất, định nghĩa thành public và static. Client chỉ dùng getInstance() để tạo đổi tượng cho lớp Singleton.
- Thực hiện hàm khởi tạo chậm (lazay initiazation) trong getInstance(): chỉ khi gọi phương thức getInstance() có khởi tại đối tượng. Phương thức này trả về một instance mới hay null tùy thuộc vào một tham số kiểu boolean dùng như cờ hiệu báo hiệu xem lớp Singleton đã instance hay chưa.

*Ví dụ về cách tạo ra 1 Singleton:*

  ![image](https://user-images.githubusercontent.com/65171477/168467012-f5cf3a99-72ce-41eb-a2bc-013c10dacc0f.png)


  Ngoài ra Singleton còn được ứng dụng trong:
- Abstract Factory: thường là Singleton để trả về các đối tượng factory duy nhất.
- Builder: dùng để xây dựng một đối tượng phức tạp, trong đó Singleton được dùng để tạo một đối tượng truy cập tổng quát (Director).
- Prototype: dùng để sao chép một đối tượng, hoặc tạo ra một đối tượng khác từ Prototype của nó, trong đó Singleton được dùng để chắc chắn chỉ có một Prototype.
- Lớp java.lang.Runtime là lớp Singleton, để lấy được đối tượng duy nhất của nó, ta gọi phương thức getRuntime(). Tương tự, lớp java.awt.Desktop cũng là lớp Singleton, tạo đối tượng duy nhất bằng phương thức getDesktop(). Singleton không phổ biến như ta nghỉ, nó chỉ áp dụng với lớp cần bảo đảm chỉ có một thể hiện duy nhất.

1.4. *Các cách Implement Singleton Pattern*
  **Eager initialization**

  ![image](https://user-images.githubusercontent.com/65171477/168467016-a16366ce-0e6d-4ea9-bc31-aed34b68a5a8.png)


  Đây là cách dễ nhất nhưng nó có một nhược điểm là mặc dù instance đã được khởi tạo nhưng có thể sẽ không dùng tới.

  **Lazy initialization**

  ![image](https://user-images.githubusercontent.com/65171477/168467021-ad418e6d-a50a-4d52-9ff2-c75367fe06b3.png)

  Cách này đã khắc phục được nhược điểm của Eager initialization, chỉ khi nào geInstance() được gọi thì instance mới được khởi tạo. Tuy nhiên cách này chỉ sử dụng tốt trong trường hợp đơn luồng, trường hợp nếu có 2 luồng cùng chạy và cùng gọi hàm getInstance tại cùng một thời điểm thì đương nhiên chúng ta có ít nhất 2 thể hiện của instance. 

  **Thread Safe initialization**

  ![image](https://user-images.githubusercontent.com/65171477/168467027-31c4c3b6-734c-459f-b3a3-de71bf72e4cf.png)

  Cách đơn gảin nhất là chúng ta gọi phương thức synchronized của hàm getInstance() và như vậy hệ thống đảm bảo rằng tại cùng một thời điểm chỉ có thể có 1 luồng có thể truy cập vào hàm getInstance(), và đảm bảo rằng chỉ có duy nhất 1 thể hiện của class Tuy nhiên một menthod synchronized sẽ chạy rất chậm và tốn hiệu năng vì vậy chúng ta cần cải tiến nó đi 1 chút.

  **Thread Safe Upgrade initialization**
  Mình tạm gọi nó là Thread Safe Upgrade initialization, thay vì chúng ta Thread Safe cả menthod getInstance() chúng ta chỉ Thread Safe một đoạn mã quan trọng:

  ![image](https://user-images.githubusercontent.com/65171477/168467035-3598ef71-374b-45b5-9a09-bdc69253ebc4.png)


1.5. Lưu ý
  -	Các pattern khác có thể dùng cùng Singleton. Chẳng hạn, Abstract Factory, Builder, Prototype (sẽ trình bày cụ thể trong từng bài riêng cho mỗi pattern). Các đối tượng Facade và State cũng thường là Singleton.
  - Không nên hiểu máy móc rằng Singleton nghĩa là tồn tại chính xác 1 thể hiện. Có thể có những thể hiện khác nhau cho những mục đích khác nhau. Đây cũng là ưu điểm của Singleton so với việc dùng biến toàn cục (global variable)

  -	Singleton là toàn cục. Vì vậy, khi đơn giản là muốn truyền một đối tượng A cho đối tượng B xử lý, hãy cân nhắc xem bạn có thật sự cần một đối tượng toàn cục hay không. Giống như thời trang vậy, che bao nhiêu, khoe bao nhiêu, bạn phải tự tìm lấy một điểm cân bằng.

  -	Thận trọng với đa luồng (multithreading). Hai luồng khác nhau có thể gọi phương thức khởi tạo ở cùng một thời điểm và sinh ra hai thể hiện. Trong khi đó, đồng bộ (synchronized) phương thức khởi tạo lại ảnh hưởng tới hiệu suất.

### 2. **Strategy pattern**
2.1.* Strategy Pattern là gì?*
  Là một trong những Pattern thuộc nhóm hành vi (Behavior Pattern), Strategy Pattern  cho phép định nghĩa tập hợp các thuật toán, đóng gói từng thuật toán lại, và dễ dàng thay đổi linh hoạt các thuật toán bên trong object. Strategy cho phép thuật toán biến đổi độc lập khi người dùng sử dụng chúng.
  Strategy giúp tách rời phần xử lý một chức năng cụ thể ra khỏi đối tượng. Tiếp theo đó xử lý chức năng đó bằng cách tạo ra một tập hợp các thuật toán và lựa chọn thuật toán chúng đắn nhất khi thực thi chương trình. Strategy được sử dụng thay thế cho sự kế thừa, khi muốn chấm dứt việc theo dõi và chỉnh sửa một chức năng qua nhiều lớp con.
2.2*Cài đặt Strategy Pattern*

  ![image](https://user-images.githubusercontent.com/65171477/168467040-40e80bf6-074c-4bcf-baea-fbfab09aad87.png)

  **Strategy:** định nghĩa các hành vi có thể có của một Strategy.
  **Concrete Strategy:** các hành bị cụ thể được cài đặt của Strategy.
  **Context:**nhận các yêu cầu từ Client
2.3.Ưu và nhược điểm
  **Ưu điểm:**
  - Dễ dàng thay đổi các thuật toán được sử dụng bên trong một đối tượng tại thời điểm run-time
  - Đảm bảo nguyên tắc OCP: chúng ta dễ dàng mở rộng và kết hợp hành vi mới mà không thay đổi ứng dụng.
  - Đảm bảo nguyên tắc SRP: một lớp định nghĩa nhiều hành vi và chúng xuất hiện dưới dạng với nhiều câu lệnh có điều kiện. Thay vì nhiều điều kiện, chúng ta sẽ chuyển các nhánh có điều kiện liên quan vào lớp Strategy riêng lẻ của nó.

  - Phù hợp để che dấu sự phức tạp cũng như cấu trúc của thuật toán.

  **Nhược điểm:**
  - Không phù hợp với chương trình chỉ có một vài thuật toán mà chúng hiếm khi thay đổi.
  - Client phải tìm hiểu khác nhau giữa các Concrete để có thể chọn được phù hợp nhất.
### 3.**Factory?**
3.1. *Factory Method là gì ?*

  Factory Method giống như tên gọi thì Pattern này như một nhà máy sẽ sản xuất ra các đối tượng theo yêu cầu. Đây là Pattern thuộc nhóm Creational Design Pattern. Nhiệm vụ của nó quản lý và trả về các đối tượng theo yêu cầu, giúp cho việc khởi tạo đối tượng một cách linh hoạt hơn.
Một Factory Pattern bao gồm các thành phần cơ bản sau:
  - Super Class: một superclass trong Factory Pattern có thể là một interface, abstract class hay một class thông thường.
  - Sub Classes: các subclass sẽ implement các phương thức của superclass theo nghiệp vụ riêng của nó.
  - Factory Class: một class chịu trách nhiệm khởi tạo các đối tượng subclass dựa theo tham số đầu vào. Lưu ý: lớp này là Singleton hoặc cung cấp một public static method cho việc truy xuất và khởi tạo đối tượng. Factory class sử dụng if-else hoặc switch-case để xác định class con đầu ra.

3.2.*Áp dụng thực tế*
  Khi xây dựng một ứng dụng về tự động hóa, ban đầu chỉ xây dựng vận chuyển hàng hóa với xe tải. Tuy nhiên, sau một thời gian phát triển công ty mở rộng thêm vận chuyển hành khách với xe Khách. Khi mới xây dựng, ứng dụng chỉ áp dụng cho vận chuyển hàng hóa nên bây giờ code đã không phù hợp vì loại phương tiện lúc này đã có thêm xe khách. Nếu như trong tương lai công ty phát triển thêm nhiều phương tiện thì code lại phát sinh nhiều vấn đề khác. Đó là một thách thức lớn khi xây dựng ứng dụng.
Giải pháp được đề xuất ở đây là thay thế việc khởi tạo đối tượng trong constructor bởi từ khóa new object bằng việc gọi một phương thức đặc biệt gọi là factory. Ta thấy một class con đều có thể ghi đè phương thức tạo object, điều này giúp tạo nhiều object với từng nhu cầu khác nhau. Điều này giúp dễ dàng thêm các object về sau mà không cần thay đổi code.
  ![image](https://user-images.githubusercontent.com/65171477/168467049-b98a5b0d-f0f4-40fa-8404-526c45726530.png)


3.3*Cài đặt Factory Method*

  ![image](https://user-images.githubusercontent.com/65171477/168467056-2b3d9a4e-27b0-4061-9046-28cb90e51d22.png)


  Trong đó:
  - Product: Là interface mà có đặc tính phổ biến nhất để tạo các sản phẩm trong class con. Ví dụ với bài toán đề cập nó là ICar.
  - Concrete Products: Là các sản phẩm cụ thể sau khi được tạo thông qua factory method
  - Creator: Đây sẽ là nơi tạo ra factory method. Điểm quan trọng ở đây đó là kiểu trả về của factory method phải là kiểu Product. Bạn có thể khai báo factory method với kiểu abstract như vậy các class con có thể ghi đè nó.
3.4*Ưu và nhược điểm*
  **Ưu điểm**
   *Tránh việc gắn chặt việc tạo sản phẩm với bất kỳ một loại sản phẩm cụ thể nào.
  - Single Responsibility Principle: Bạn có thể chuyển code tạo sản phẩm đến một nơi trong chương trình, làm cho việc maintain dễ dàng hơn.
  - Open/Closed Principle: Như những mô tả ở trên, chúng ta có thể dễ dàng thêm một kiểu sản phẩm mới mà không làm ảnh hưởng đến code hiện tại
  **Nhược điểm**
  - Code sẽ trở nên phức tạp khi có quá nhiều class con để triển khai pattern

### 4.**Adapter**

4.1. *Adapter pattern là gì ?*

  Adapter pattern là một mẫu thiết kế phần mềm, Adapter Pattern nằm trong nhóm Cấu trúc — Structural Pattern — liên quan đến cấu trúc cho toàn hệ thống, tập trung vào các mối quan hệ giữa các thực thể, các component, làm cho chúng tương tác dễ dàng với nhau hơn. Adapter Pattern đóng vai trò trung gian, tương thích cho hệ thống sẵn có đối ứng với các component mới mà không cần phải sửa đổi code, cho phép các interface không liên quan đến nhau có thể làm việc cùng nhau
4.2.*Cài đặt Adapter Pattern*
  Một Adapter Pattern bao gồm các thành phần cơ bản sau:
  - Adaptee: định nghĩa interface không tương thích, cần được tích hợp vào.
  - Adapter: lớp tích hợp, giúp interface không tương thích tích hợp được với interface đang làm việc. Thực hiện việc chuyển đổi interface cho Adapter và kết nối Adapter với Client.

  - Target: một interface chứa các chức năng được sử dụng bởi Client (domain specific).
  - Client: lớp sử dụng các đối tượng có interface Target.
  Có hai cách để thực hiện Adapter Pattern dựa theo cách cài đặt (implement) của chúng:
  - **Object Adapter – Composition (Chứa trong):**  trong mô hình này, một lớp mới (Adapter) sẽ tham chiếu đến một (hoặc nhiều) đối tượng của lớp có sẵn với interface không tương thích (Adaptee), đồng thời cài đặt interface mà người dùng mong muốn (Target). Trong lớp mới này, khi cài đặt các phương thức của interface người dùng mong muốn, sẽ gọi phương thức cần thiết thông qua đối tượng thuộc lớp có interface không tương thích.
  
  ![image](https://user-images.githubusercontent.com/65171477/168467096-940e93fe-1dea-4d29-94e9-64bc2e7601ab.png)

  - **Class Adapter – Inheritance (Kế thừa)** trong mô hình này, một lớp mới (Adapter) sẽ kế thừa lớp có sẵn với interface không tương thích (Adaptee), đồng thời cài đặt interface mà người dùng mong muốn (Target). Trong lớp mới, khi cài đặt các phương thức của interface người dùng mong muốn, phương thức này sẽ gọi các phương thức cần thiết mà nó thừa kế được từ lớp có interface không tương thích.

  ![image](https://user-images.githubusercontent.com/65171477/168467100-08f18c0e-bc02-4d2f-90a2-237ce52a87e7.png)


4.3.*Ưu và nhược điểm của Adapter Pattern*

  **Ưu điểm**
  - Sử dụng cho dự án một lớp riêng mà không đụng tới những code cũ, hay còn gọi là code gốc 
  - Tăng tính minh bạch và khả năng tái sử dụng của lớp, đóng gói việc triển khai, và khả năng tái sử dụng rất cao. Tính sẵn sàng luôn có. 
  - Tính linh hoạt và khả năng mở rộng rất tốt. Thông qua việc sử dụng các tệp cấu hình, Adapter pattern có thể dễ dàng được thay thế và có thể thêm các lớp Adapter mà không cần sửa đổi mã gốc, tuân theo nguyên tắc mở và đóng trong lập trình.
  **Nhược điểm**
  - Việc sử dụng quá nhiều mẫu thiết kế Adapter sẽ làm cho hệ thống trở nên rất lộn xộn và khó nắm bắt một cách tổng thể như các mẫu thiết kế trước như Factory pattern.
4.4. *Sử dụng Adapter Pattern khi nào?*
  Có thể dùng Adapter Pattern trong những trường hợp sau:
  - Adapter Pattern giúp nhiều lớp có thể làm việc với nhau dễ dàng mà bình thường không thể. Một trường hợp thường gặp phải và có thể áp dụng Adapter Pattern là khi không thể kế thừa lớp A, nhưng muốn một lớp B có những xử lý tương tự như lớp A. Khi đó chúng ta có thể cài đặt B theo Object Adapter, các xử lý của B sẽ gọi những xử lý của A khi cần.
  - Khi muốn sử dụng một lớp đã tồn tại trước đó nhưng interface sử dụng không phù hợp như mong muốn.

  - Khi muốn tạo ra những lớp có khả năng sử dụng lại, chúng phối hợp với các lớp không liên quan hay những lớp không thể đoán trước được và những lớp này không có những interface tương thích.

  - Cần phải có sự chuyển đổi interface từ nhiều nguồn khác nhau.

  - Khi cần đảm bảo nguyên tắc Open/ Close trong một ứng dụng.

# Chương 3: Triển khai ứng dụng
### 3.1. **Ứng dụng các pattern (Lý do chọn pattern)**
   3.1.1.*Singleton*
   
   Tránh tạo quá nhiều thực thể kết nối đến database. Do đó Singleton Pattern áp dụng vào đây thì hợp lý, tất cả chức năng nên sử dụng chung một thực thể kết nối.
   
   3.1.2.*Strategy*
   
   Vì trong ứng dụng có các hành vi như thêm , sửa , xóa , và lấy dữ liệu của người dùng và cả sản phẩm. Cả hai đối tượng người dùng đều có các hành vi trên những việc xử lý logic trong thời gian chạy  thì khác nhau. Nhằm mục đích đóng gói các phương thức trên để tiện sử dụng và chỉnh sửa trong tương lai vì những hành vì này thường rất dễ thay đổi trong quá trình phát triển. Nên dùng Strategy Method ở đây là hợp lý.
   3.1.3. *Factory*
   
  - Khi muốn xác thực dữ liệu khi chưa biết trước tất cả các loại dữ liệu sẽ được xác thực. Để khi mở rộng sau này không cần phải thay đổi code khi thêm các loại dữ liệu cần xác thực khác.
  - Ngoài ra giúp giảm sự phụ thuộc và giúp chương trình độc lập với những lớp cụ thể mà khi tạo một đối tượng code ở phía client không bị ảnh hưởng khi thay đổi logic ở factory hoặc subclass.
  - Thông nhất về naming convention ( quy tắc đặt tên) giúp cho các thành viên trong nhóm có thể hiểu được cấu trúc của method này một cách dễ dàng hơn.

  VD:
  
  ![image](https://user-images.githubusercontent.com/65171477/168467115-f625b164-63f5-4090-bbd0-b1d7ae12007e.png)

  Ví dụ về chức năng đăng kí tài khoản:
 
   Ban đầu chỉ cần xác thực 2 thông tin email và số điện thoại. Nhưng sau này khi mở rộng hệ thống ta có thể thêm một vài trường dữ liệu khác cần được xác thực như hình ảnh , CMND,... Thì ta không cần sửa code ban đầu mà chỉ cẩn bổ sung thêm các subclass ( ví dụ CMNDValidateFactory.cs …) cần dùng để xác thực và implement vào ValidateFactory method.
    
   3.1.4. *Adapter*
   Khi gửi dữ liệu từ phía client lên server thì dữ liệu cần được thêm vào chưa tương thích với database do khác định dạng dữ liệu. Vì vậy cần phải chuyển đổi dữ liệu về đúng định dạng dữ liệu trong database mới thêm vào được. Do có nhiều nơi cần phải chuyển đổi dữ liệu và để tránh mất thời gian chỉnh sửa từng nơi khi định dạng trong database thay đổi thì sử dụng Adapter method ở đây là hợp lí nhất.
    VD:
    Khi người dùng đăng kí tài khoản thì các dữ liệu gửi lên trong RegisterData có các cột như sau:
    
   ![image](https://user-images.githubusercontent.com/65171477/168467128-ed542720-69ed-4abd-a83e-cf98716e7f96.png)


  Khi đăng kí tài khoản thành công thì thông tin người dùng cần được lưu vào database User có các cột như sau:

  ![image](https://user-images.githubusercontent.com/65171477/168467141-fb3cf9cd-f5d4-4d92-9772-32217719ce82.png)


   Ở RegisterData : Không có cột id, và có ConfirmPassword

   Ở User : Có cột id và không có có cột ConfirmPassword
    Nhiệm vụ của Adapter Method là chuyển đổi đối tượng RegisterData trở thành đối tượng User để đảm bảo rằng đối tượng RegisterData từ người dùng gửi lên vẫn được xử lí

### 3.2. **Sơ đồ lớp**
  3.2.1. *Singleton*
  
  ![image](https://user-images.githubusercontent.com/65171477/168467152-dbf4bd95-ec37-499b-b961-bb35182b4016.png)

3.2.2. *Strategy*

  ![image](https://user-images.githubusercontent.com/65171477/168467155-b439cce7-e15a-4d36-abd4-a10a68436875.png)

3.2.3. *Factory*

  ![image](https://user-images.githubusercontent.com/65171477/168467163-3dcac4c3-1177-498d-bd22-b5ce5387d306.png)

3.2.4. *Adapter*

  ![image](https://user-images.githubusercontent.com/65171477/168467168-bcd23158-0a04-46a0-982c-e9e8b888a830.png)


### 3.3. **Kết quả thực tế**

# Chương 4 - Kết luận
### Hướng dẫn chạy code
   *Khởi chạy server:*
   - Mở Visual Studio 2022 chọn clone project về
   - Chọn file web-shop.sln và open
   - Bấm tổ hợp phím Ctrl + Shift + B để build project ( Có thể mất vài phút)
   -Bấm vào icon run ở thanh công cụ hoặc tô hợp phím ( Ctrl + F5) để run server
ở local

  *Giao diện tương tác với demo*
   - link: https://khanhpro1250.github.io/web-fashion/
### Các api có trong demo
  *Cart Product*
  
  ![image](https://user-images.githubusercontent.com/65171477/168483063-b89d93a1-d67d-4cc6-9c0f-508af521e0c5.png)
  
  *Order*
  
  ![image](https://user-images.githubusercontent.com/65171477/168483100-764b746e-7058-4f26-a94e-9abd4b1a68d1.png)

  *Product*
  
  ![image](https://user-images.githubusercontent.com/65171477/168483110-7635ca99-9e7d-4e61-9954-875356cbfd2b.png)

  *User*
  
  ![image](https://user-images.githubusercontent.com/65171477/168483123-8e7b266b-ffbd-422f-be40-2bc7173bdc68.png)
  
  
#### Example get product respones
```json
{
    "code": 0,
    "message": "Success",
    "products": [
        {
            "id": "62679e2caa0a6994034378f1",
            "productName": "Nike Air Force 1 '07 LV8",
            "productId": "nikeAir1'07v8",
            "typeProduct": "shoes",
            "price": 3239000,
            "amount": 100,
            "discount": 5,
            "size": "43",
            "description": "This iteration of our iconic Nike Air Force 1 '07 LV8 has hoops-inspired performance features that provide a comfortable base with flashing-light-activated design details.",
            "subtitle": "This iteration of our iconic Nike Air Force 1 '07 LV8 has hoops-inspired performance features that provide a comfortable base with flashing-light-activated design details.",
            "imgLink": "https://res.cloudinary.com/khanh15032001/image/upload/v1650957823/yx94kalc9u6v9s4qllr3.webp"
        },
        {
            "id": "627a8e25cb053cc04871d04e",
            "productName": "Nike Air Force 1 LV8",
            "productId": "NAF1LV8",
            "typeProduct": "shoes",
            "price": 5000000,
            "amount": 100,
            "discount": 5,
            "size": "43",
            "description": "A basketball legend turned streetwear icon, the Nike Air Force 1 LV8 returns with a remake of the '82 classic. Still durable, it also has the comfy Air-Sole unit you know and love. This edition pays tribute to our history with \"Nike Athletic Club\" details and early '70s style.",
            "subtitle": "Colour Shown: Off-Noir/White/Off-Noir/Pink Prime\nStyle: DH9597-003",
            "imgLink": "https://res.cloudinary.com/khanh15032001/image/upload/v1652198931/lzoi44tfc6wq6ezfea3i.webp"
        }
     ]
}

```



