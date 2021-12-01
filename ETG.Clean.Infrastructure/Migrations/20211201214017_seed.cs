using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETG.Clean.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "448bee34-7aaf-4f9a-bb7f-1da82fdad254", 0, "452ada90-48d5-45eb-8422-4e91f8db5ae4", "andi.toci@etg.al", true, true, null, "ANDI.TOCI@ETG.AL", "ANDI.TOCI@ETG.AL", "AQAAAAEAACcQAAAAEEum9nf1otPE8r/1F43uIwX3fr0LncDlgGSgDvWFaLXg1Y2W/6VUBiHP2JZLKGOkig==", null, false, "607fccf8-772d-48cf-8aa9-9337c9f71523", false, "andi.toci@etg.al" },
                    { "d2d92f37-7fb8-494e-bc06-79bf1207cf0a", 0, "deee9c94-7bed-4ac1-9673-dfb223b85127", "bagheri.saleh@gmail.com", true, true, null, "BAGHERI.SALEH@GMAIL.COM", "BAGHERI.SALEH@GMAIL.COM", "AQAAAAEAACcQAAAAEIwIZT0RK8sm2Fraz/rEhJa46OJIyxGGZAdYJypTztzuhJw8UmsXTNQSDUkSIfX8kQ==", null, false, "4da9dcb3-fd43-425f-8c42-f2785b11121b", false, "bagheri.saleh@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateOn", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("682b45de-3aaf-3f9a-237f-1da825dad254"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 39, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 1, 0, 0, 0)), "Books Desc", "Books" },
                    { new Guid("45d92f47-6fb8-222e-abb6-79bf1207cf0a"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 41, DateTimeKind.Unspecified).AddTicks(7234), new TimeSpan(0, 1, 0, 0, 0)), "Computers Desc", "Computers" },
                    { new Guid("a45f062e-6215-491d-8d99-49074f1a1369"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 41, DateTimeKind.Unspecified).AddTicks(7274), new TimeSpan(0, 1, 0, 0, 0)), "Cameras Desc", "Cameras" },
                    { new Guid("96584462-2851-4c95-ad55-5eefe75a8cb2"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 41, DateTimeKind.Unspecified).AddTicks(7283), new TimeSpan(0, 1, 0, 0, 0)), "Mobiles Desc", "Mobiles" },
                    { new Guid("70ec5574-f551-46f3-a76c-d1163d565901"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 41, DateTimeKind.Unspecified).AddTicks(7287), new TimeSpan(0, 1, 0, 0, 0)), "Stationary Desc", "Stationary" },
                    { new Guid("4085a3bb-509f-464d-a876-e4dc6a2740a7"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 41, DateTimeKind.Unspecified).AddTicks(7291), new TimeSpan(0, 1, 0, 0, 0)), "Apparel Desc", "Apparel" },
                    { new Guid("c8e188ff-d15b-4cdf-ac5e-696417c7cb69"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 41, DateTimeKind.Unspecified).AddTicks(7294), new TimeSpan(0, 1, 0, 0, 0)), "Shoes Desc", "Shoes" },
                    { new Guid("50726abd-d9c7-4235-9f1f-2e9edcf906ff"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 41, DateTimeKind.Unspecified).AddTicks(7307), new TimeSpan(0, 1, 0, 0, 0)), "Furnitures Desc", "Furnitures" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateOn", "Description", "ImageUrl", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("d32bee34-3aaf-3f9a-cb7f-1da82fdad254"), new DateTimeOffset(new DateTime(2021, 11, 30, 21, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(904), new TimeSpan(0, 0, 0, 0, 0)), "<p> Interdum himenaeos sagittis feugiat egestas justo varius. Volutpat himenaeos turpis quis aliquet class nostra. Cum amet aenean, quis nullam. Mus justo facilisi tellus mauris tempus sed! Pretium quam cras at in platea nascetur cursus primis tincidunt nibh sollicitudin. Facilisi orci cum aliquam porta. Ridiculus curabitur, nisl faucibus pellentesque massa aliquam. Elementum donec viverra urna iaculis quam dignissim libero taciti neque. Quis lacinia suscipit non congue et dui gravida donec. Rutrum varius sociis proin integer venenatis taciti semper penatibus iaculis tortor sed. Rutrum malesuada habitant dictum, semper ornare purus. Magna tortor elementum lectus aptent volutpat faucibus interdum eget nisi. </p> <p> Erat, facilisi per pellentesque. Tristique imperdiet taciti mauris ac egestas imperdiet nullam taciti! Rutrum tortor elementum vitae molestie lobortis. Proin sit curae; scelerisque nam porta odio imperdiet nascetur malesuada risus. Eu euismod vestibulum viverra. Hac fusce quis nascetur. Cum scelerisque malesuada hac varius morbi conubia quis taciti leo integer. Lobortis. </p> <p> Imperdiet senectus commodo ante velit turpis leo. Diam ac netus sagittis eget. Nostra pharetra per cursus mus vulputate fusce ornare platea sollicitudin suscipit bibendum potenti. Pretium augue odio nunc in. Purus amet eu, tortor per varius congue. Blandit lobortis parturient ac class cum. Vestibulum pulvinar metus praesent feugiat ut ridiculus semper dapibus suspendisse ut lectus. Cras velit libero augue morbi quisque feugiat convallis ac? Justo tortor purus ridiculus duis mollis auctor dictum sociosqu non lobortis ut. Vel curabitur praesent libero? Id arcu senectus ullamcorper elementum felis rhoncus integer curae; quis. Torquent iaculis accumsan habitasse posuere ligula sit ullamcorper sed auctor inceptos posuere. Auctor hac pulvinar nibh. Egestas vivamus taciti, id posuere feugiat porta laoreet sed hendrerit taciti lacinia. Nunc vitae condimentum. </p> <p> Ipsum feugiat ligula fusce. Nam mi et tellus molestie justo lacus dictum varius phasellus conubia pretium cubilia. Maecenas magnis consequat varius aenean aptent. Varius sociis ac dis facilisis scelerisque ante turpis. Consectetur ac non tempus pulvinar semper felis hac senectus. Cum aenean lacus porta libero scelerisque rhoncus penatibus mi sit vitae rhoncus dis. Nam leo tempus velit, habitasse porttitor eu ultrices orci? Porttitor eu placerat nostra risus! </p> <p> Nulla elementum nunc adipiscing nulla turpis duis quam? Curae; venenatis magnis imperdiet nisi laoreet vel dictumst. Blandit sodales iaculis rutrum class inceptos aptent ipsum tempus conubia id. Justo ac inceptos habitant. Cubilia, ac elementum vivamus velit amet egestas venenatis litora fames maecenas aptent. Posuere facilisis platea bibendum eleifend. Praesent mollis purus purus. Quam aliquet a conubia. Lorem magna curabitur purus tincidunt nisi. Libero ornare. </p>", "Images/Sample/1.jpg", "Interdum himenaeos sagittis feugiat egestas", "448bee34-7aaf-4f9a-bb7f-1da82fdad254" },
                    { new Guid("739ac52e-cbe2-4411-9a01-335d12405dda"), new DateTimeOffset(new DateTime(2021, 11, 28, 21, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(1553), new TimeSpan(0, 0, 0, 0, 0)), "<p> Interdum himenaeos sagittis feugiat egestas justo varius. Volutpat himenaeos turpis quis aliquet class nostra. Cum amet aenean, quis nullam. Mus justo facilisi tellus mauris tempus sed! Pretium quam cras at in platea nascetur cursus primis tincidunt nibh sollicitudin. Facilisi orci cum aliquam porta. Ridiculus curabitur, nisl faucibus pellentesque massa aliquam. Elementum donec viverra urna iaculis quam dignissim libero taciti neque. Quis lacinia suscipit non congue et dui gravida donec. Rutrum varius sociis proin integer venenatis taciti semper penatibus iaculis tortor sed. Rutrum malesuada habitant dictum, semper ornare purus. Magna tortor elementum lectus aptent volutpat faucibus interdum eget nisi. </p> <p> Erat, facilisi per pellentesque. Tristique imperdiet taciti mauris ac egestas imperdiet nullam taciti! Rutrum tortor elementum vitae molestie lobortis. Proin sit curae; scelerisque nam porta odio imperdiet nascetur malesuada risus. Eu euismod vestibulum viverra. Hac fusce quis nascetur. Cum scelerisque malesuada hac varius morbi conubia quis taciti leo integer. Lobortis. </p> <p> Imperdiet senectus commodo ante velit turpis leo. Diam ac netus sagittis eget. Nostra pharetra per cursus mus vulputate fusce ornare platea sollicitudin suscipit bibendum potenti. Pretium augue odio nunc in. Purus amet eu, tortor per varius congue. Blandit lobortis parturient ac class cum. Vestibulum pulvinar metus praesent feugiat ut ridiculus semper dapibus suspendisse ut lectus. Cras velit libero augue morbi quisque feugiat convallis ac? Justo tortor purus ridiculus duis mollis auctor dictum sociosqu non lobortis ut. Vel curabitur praesent libero? Id arcu senectus ullamcorper elementum felis rhoncus integer curae; quis. Torquent iaculis accumsan habitasse posuere ligula sit ullamcorper sed auctor inceptos posuere. Auctor hac pulvinar nibh. Egestas vivamus taciti, id posuere feugiat porta laoreet sed hendrerit taciti lacinia. Nunc vitae condimentum. </p> <p> Ipsum feugiat ligula fusce. Nam mi et tellus molestie justo lacus dictum varius phasellus conubia pretium cubilia. Maecenas magnis consequat varius aenean aptent. Varius sociis ac dis facilisis scelerisque ante turpis. Consectetur ac non tempus pulvinar semper felis hac senectus. Cum aenean lacus porta libero scelerisque rhoncus penatibus mi sit vitae rhoncus dis. Nam leo tempus velit, habitasse porttitor eu ultrices orci? Porttitor eu placerat nostra risus! </p> <p> Nulla elementum nunc adipiscing nulla turpis duis quam? Curae; venenatis magnis imperdiet nisi laoreet vel dictumst. Blandit sodales iaculis rutrum class inceptos aptent ipsum tempus conubia id. Justo ac inceptos habitant. Cubilia, ac elementum vivamus velit amet egestas venenatis litora fames maecenas aptent. Posuere facilisis platea bibendum eleifend. Praesent mollis purus purus. Quam aliquet a conubia. Lorem magna curabitur purus tincidunt nisi. Libero ornare. </p>", "Images/Sample/3.jpg", "Velit magnis nullam consectetur", "448bee34-7aaf-4f9a-bb7f-1da82fdad254" },
                    { new Guid("f8c0ee7a-467e-4a40-b849-8aa52673b5da"), new DateTimeOffset(new DateTime(2021, 11, 26, 21, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(1565), new TimeSpan(0, 0, 0, 0, 0)), "<p> Interdum himenaeos sagittis feugiat egestas justo varius. Volutpat himenaeos turpis quis aliquet class nostra. Cum amet aenean, quis nullam. Mus justo facilisi tellus mauris tempus sed! Pretium quam cras at in platea nascetur cursus primis tincidunt nibh sollicitudin. Facilisi orci cum aliquam porta. Ridiculus curabitur, nisl faucibus pellentesque massa aliquam. Elementum donec viverra urna iaculis quam dignissim libero taciti neque. Quis lacinia suscipit non congue et dui gravida donec. Rutrum varius sociis proin integer venenatis taciti semper penatibus iaculis tortor sed. Rutrum malesuada habitant dictum, semper ornare purus. Magna tortor elementum lectus aptent volutpat faucibus interdum eget nisi. </p> <p> Erat, facilisi per pellentesque. Tristique imperdiet taciti mauris ac egestas imperdiet nullam taciti! Rutrum tortor elementum vitae molestie lobortis. Proin sit curae; scelerisque nam porta odio imperdiet nascetur malesuada risus. Eu euismod vestibulum viverra. Hac fusce quis nascetur. Cum scelerisque malesuada hac varius morbi conubia quis taciti leo integer. Lobortis. </p> <p> Imperdiet senectus commodo ante velit turpis leo. Diam ac netus sagittis eget. Nostra pharetra per cursus mus vulputate fusce ornare platea sollicitudin suscipit bibendum potenti. Pretium augue odio nunc in. Purus amet eu, tortor per varius congue. Blandit lobortis parturient ac class cum. Vestibulum pulvinar metus praesent feugiat ut ridiculus semper dapibus suspendisse ut lectus. Cras velit libero augue morbi quisque feugiat convallis ac? Justo tortor purus ridiculus duis mollis auctor dictum sociosqu non lobortis ut. Vel curabitur praesent libero? Id arcu senectus ullamcorper elementum felis rhoncus integer curae; quis. Torquent iaculis accumsan habitasse posuere ligula sit ullamcorper sed auctor inceptos posuere. Auctor hac pulvinar nibh. Egestas vivamus taciti, id posuere feugiat porta laoreet sed hendrerit taciti lacinia. Nunc vitae condimentum. </p> <p> Ipsum feugiat ligula fusce. Nam mi et tellus molestie justo lacus dictum varius phasellus conubia pretium cubilia. Maecenas magnis consequat varius aenean aptent. Varius sociis ac dis facilisis scelerisque ante turpis. Consectetur ac non tempus pulvinar semper felis hac senectus. Cum aenean lacus porta libero scelerisque rhoncus penatibus mi sit vitae rhoncus dis. Nam leo tempus velit, habitasse porttitor eu ultrices orci? Porttitor eu placerat nostra risus! </p> <p> Nulla elementum nunc adipiscing nulla turpis duis quam? Curae; venenatis magnis imperdiet nisi laoreet vel dictumst. Blandit sodales iaculis rutrum class inceptos aptent ipsum tempus conubia id. Justo ac inceptos habitant. Cubilia, ac elementum vivamus velit amet egestas venenatis litora fames maecenas aptent. Posuere facilisis platea bibendum eleifend. Praesent mollis purus purus. Quam aliquet a conubia. Lorem magna curabitur purus tincidunt nisi. Libero ornare. </p>", "Images/Sample/5.jpg", "Habitant volutpat sociis donec fames", "448bee34-7aaf-4f9a-bb7f-1da82fdad254" },
                    { new Guid("32d92f47-6fb8-494e-aa06-79bf1207cf0a"), new DateTimeOffset(new DateTime(2021, 11, 29, 21, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(1538), new TimeSpan(0, 0, 0, 0, 0)), "<p> Interdum himenaeos sagittis feugiat egestas justo varius. Volutpat himenaeos turpis quis aliquet class nostra. Cum amet aenean, quis nullam. Mus justo facilisi tellus mauris tempus sed! Pretium quam cras at in platea nascetur cursus primis tincidunt nibh sollicitudin. Facilisi orci cum aliquam porta. Ridiculus curabitur, nisl faucibus pellentesque massa aliquam. Elementum donec viverra urna iaculis quam dignissim libero taciti neque. Quis lacinia suscipit non congue et dui gravida donec. Rutrum varius sociis proin integer venenatis taciti semper penatibus iaculis tortor sed. Rutrum malesuada habitant dictum, semper ornare purus. Magna tortor elementum lectus aptent volutpat faucibus interdum eget nisi. </p> <p> Erat, facilisi per pellentesque. Tristique imperdiet taciti mauris ac egestas imperdiet nullam taciti! Rutrum tortor elementum vitae molestie lobortis. Proin sit curae; scelerisque nam porta odio imperdiet nascetur malesuada risus. Eu euismod vestibulum viverra. Hac fusce quis nascetur. Cum scelerisque malesuada hac varius morbi conubia quis taciti leo integer. Lobortis. </p> <p> Imperdiet senectus commodo ante velit turpis leo. Diam ac netus sagittis eget. Nostra pharetra per cursus mus vulputate fusce ornare platea sollicitudin suscipit bibendum potenti. Pretium augue odio nunc in. Purus amet eu, tortor per varius congue. Blandit lobortis parturient ac class cum. Vestibulum pulvinar metus praesent feugiat ut ridiculus semper dapibus suspendisse ut lectus. Cras velit libero augue morbi quisque feugiat convallis ac? Justo tortor purus ridiculus duis mollis auctor dictum sociosqu non lobortis ut. Vel curabitur praesent libero? Id arcu senectus ullamcorper elementum felis rhoncus integer curae; quis. Torquent iaculis accumsan habitasse posuere ligula sit ullamcorper sed auctor inceptos posuere. Auctor hac pulvinar nibh. Egestas vivamus taciti, id posuere feugiat porta laoreet sed hendrerit taciti lacinia. Nunc vitae condimentum. </p> <p> Ipsum feugiat ligula fusce. Nam mi et tellus molestie justo lacus dictum varius phasellus conubia pretium cubilia. Maecenas magnis consequat varius aenean aptent. Varius sociis ac dis facilisis scelerisque ante turpis. Consectetur ac non tempus pulvinar semper felis hac senectus. Cum aenean lacus porta libero scelerisque rhoncus penatibus mi sit vitae rhoncus dis. Nam leo tempus velit, habitasse porttitor eu ultrices orci? Porttitor eu placerat nostra risus! </p> <p> Nulla elementum nunc adipiscing nulla turpis duis quam? Curae; venenatis magnis imperdiet nisi laoreet vel dictumst. Blandit sodales iaculis rutrum class inceptos aptent ipsum tempus conubia id. Justo ac inceptos habitant. Cubilia, ac elementum vivamus velit amet egestas venenatis litora fames maecenas aptent. Posuere facilisis platea bibendum eleifend. Praesent mollis purus purus. Quam aliquet a conubia. Lorem magna curabitur purus tincidunt nisi. Libero ornare. </p>", "Images/Sample/2.jpg", "Volutpat himenaeos turpis quis", "d2d92f37-7fb8-494e-bc06-79bf1207cf0a" },
                    { new Guid("3b5110d9-0791-4cad-9964-49d8d4bacecc"), new DateTimeOffset(new DateTime(2021, 11, 27, 21, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 0, 0, 0, 0)), "<p> Interdum himenaeos sagittis feugiat egestas justo varius. Volutpat himenaeos turpis quis aliquet class nostra. Cum amet aenean, quis nullam. Mus justo facilisi tellus mauris tempus sed! Pretium quam cras at in platea nascetur cursus primis tincidunt nibh sollicitudin. Facilisi orci cum aliquam porta. Ridiculus curabitur, nisl faucibus pellentesque massa aliquam. Elementum donec viverra urna iaculis quam dignissim libero taciti neque. Quis lacinia suscipit non congue et dui gravida donec. Rutrum varius sociis proin integer venenatis taciti semper penatibus iaculis tortor sed. Rutrum malesuada habitant dictum, semper ornare purus. Magna tortor elementum lectus aptent volutpat faucibus interdum eget nisi. </p> <p> Erat, facilisi per pellentesque. Tristique imperdiet taciti mauris ac egestas imperdiet nullam taciti! Rutrum tortor elementum vitae molestie lobortis. Proin sit curae; scelerisque nam porta odio imperdiet nascetur malesuada risus. Eu euismod vestibulum viverra. Hac fusce quis nascetur. Cum scelerisque malesuada hac varius morbi conubia quis taciti leo integer. Lobortis. </p> <p> Imperdiet senectus commodo ante velit turpis leo. Diam ac netus sagittis eget. Nostra pharetra per cursus mus vulputate fusce ornare platea sollicitudin suscipit bibendum potenti. Pretium augue odio nunc in. Purus amet eu, tortor per varius congue. Blandit lobortis parturient ac class cum. Vestibulum pulvinar metus praesent feugiat ut ridiculus semper dapibus suspendisse ut lectus. Cras velit libero augue morbi quisque feugiat convallis ac? Justo tortor purus ridiculus duis mollis auctor dictum sociosqu non lobortis ut. Vel curabitur praesent libero? Id arcu senectus ullamcorper elementum felis rhoncus integer curae; quis. Torquent iaculis accumsan habitasse posuere ligula sit ullamcorper sed auctor inceptos posuere. Auctor hac pulvinar nibh. Egestas vivamus taciti, id posuere feugiat porta laoreet sed hendrerit taciti lacinia. Nunc vitae condimentum. </p> <p> Ipsum feugiat ligula fusce. Nam mi et tellus molestie justo lacus dictum varius phasellus conubia pretium cubilia. Maecenas magnis consequat varius aenean aptent. Varius sociis ac dis facilisis scelerisque ante turpis. Consectetur ac non tempus pulvinar semper felis hac senectus. Cum aenean lacus porta libero scelerisque rhoncus penatibus mi sit vitae rhoncus dis. Nam leo tempus velit, habitasse porttitor eu ultrices orci? Porttitor eu placerat nostra risus! </p> <p> Nulla elementum nunc adipiscing nulla turpis duis quam? Curae; venenatis magnis imperdiet nisi laoreet vel dictumst. Blandit sodales iaculis rutrum class inceptos aptent ipsum tempus conubia id. Justo ac inceptos habitant. Cubilia, ac elementum vivamus velit amet egestas venenatis litora fames maecenas aptent. Posuere facilisis platea bibendum eleifend. Praesent mollis purus purus. Quam aliquet a conubia. Lorem magna curabitur purus tincidunt nisi. Libero ornare. </p>", "Images/Sample/4.jpg", "Ad iaculis dictumst consequat", "d2d92f37-7fb8-494e-bc06-79bf1207cf0a" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreateOn", "PostId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("523ebe5b-579d-40aa-b9a0-963d16bc41cd"), new DateTimeOffset(new DateTime(2021, 12, 1, 21, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(4151), new TimeSpan(0, 1, 0, 0, 0)), new Guid("d32bee34-3aaf-3f9a-cb7f-1da82fdad254"), "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p> <p> Ad iaculis dictumst consequat lobortis etiam auctor ipsum dui. Ridiculus netus nostra fermentum? Elementum vulputate in augue, scelerisque eget. Class mi tortor phasellus ridiculus ullamcorper sociosqu. Pellentesque nullam, nisl tempus suspendisse aenean cursus nascetur imperdiet! Ultricies elementum mollis rutrum nisi vehicula facilisi et molestie pretium, sociis ut. Felis erat ullamcorper quisque nulla libero, purus rhoncus. Habitant felis, rhoncus enim elementum potenti facilisi imperdiet sed enim magnis. Etiam morbi ultricies sodales? </p>", "448bee34-7aaf-4f9a-bb7f-1da82fdad254" },
                    { new Guid("371a3f16-836a-43c4-97dd-1e6f2d8812a7"), new DateTimeOffset(new DateTime(2021, 12, 1, 20, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(4463), new TimeSpan(0, 1, 0, 0, 0)), new Guid("d32bee34-3aaf-3f9a-cb7f-1da82fdad254"), "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p> <p> Ad iaculis dictumst consequat lobortis etiam auctor ipsum dui. Ridiculus netus nostra fermentum? Elementum vulputate in augue, scelerisque eget. </p>", "d2d92f37-7fb8-494e-bc06-79bf1207cf0a" },
                    { new Guid("159e2211-453d-4109-9d7c-74b3d2cf1caf"), new DateTimeOffset(new DateTime(2021, 12, 1, 21, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(4455), new TimeSpan(0, 1, 0, 0, 0)), new Guid("32d92f47-6fb8-494e-aa06-79bf1207cf0a"), "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p>", "448bee34-7aaf-4f9a-bb7f-1da82fdad254" },
                    { new Guid("340eabb3-c69c-4bb2-93ef-ec6dff3b4151"), new DateTimeOffset(new DateTime(2021, 12, 1, 20, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(4470), new TimeSpan(0, 1, 0, 0, 0)), new Guid("32d92f47-6fb8-494e-aa06-79bf1207cf0a"), "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p> <p> Ad iaculis dictumst consequat lobortis etiam auctor ipsum dui. Ridiculus netus nostra fermentum? Elementum vulputate in augue, scelerisque eget. Class mi tortor phasellus ridiculus ullamcorper sociosqu. </p>", "d2d92f37-7fb8-494e-bc06-79bf1207cf0a" }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "Id", "CategoryId", "CreateOn", "PostId" },
                values: new object[,]
                {
                    { new Guid("c6afb9b5-169c-4efe-830c-6866be591358"), new Guid("682b45de-3aaf-3f9a-237f-1da825dad254"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 1, 0, 0, 0)), new Guid("d32bee34-3aaf-3f9a-cb7f-1da82fdad254") },
                    { new Guid("56c08a84-683e-42b6-a4e4-e96cdf874284"), new Guid("45d92f47-6fb8-222e-abb6-79bf1207cf0a"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(3020), new TimeSpan(0, 1, 0, 0, 0)), new Guid("d32bee34-3aaf-3f9a-cb7f-1da82fdad254") },
                    { new Guid("c68bfaa3-a123-4f81-a38f-c5d6b3f1eb97"), new Guid("45d92f47-6fb8-222e-abb6-79bf1207cf0a"), new DateTimeOffset(new DateTime(2021, 12, 1, 22, 40, 17, 42, DateTimeKind.Unspecified).AddTicks(3039), new TimeSpan(0, 1, 0, 0, 0)), new Guid("32d92f47-6fb8-494e-aa06-79bf1207cf0a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4085a3bb-509f-464d-a876-e4dc6a2740a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("50726abd-d9c7-4235-9f1f-2e9edcf906ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70ec5574-f551-46f3-a76c-d1163d565901"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96584462-2851-4c95-ad55-5eefe75a8cb2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a45f062e-6215-491d-8d99-49074f1a1369"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c8e188ff-d15b-4cdf-ac5e-696417c7cb69"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("159e2211-453d-4109-9d7c-74b3d2cf1caf"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("340eabb3-c69c-4bb2-93ef-ec6dff3b4151"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("371a3f16-836a-43c4-97dd-1e6f2d8812a7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("523ebe5b-579d-40aa-b9a0-963d16bc41cd"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("56c08a84-683e-42b6-a4e4-e96cdf874284"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("c68bfaa3-a123-4f81-a38f-c5d6b3f1eb97"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("c6afb9b5-169c-4efe-830c-6866be591358"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3b5110d9-0791-4cad-9964-49d8d4bacecc"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("739ac52e-cbe2-4411-9a01-335d12405dda"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f8c0ee7a-467e-4a40-b849-8aa52673b5da"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45d92f47-6fb8-222e-abb6-79bf1207cf0a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("682b45de-3aaf-3f9a-237f-1da825dad254"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("32d92f47-6fb8-494e-aa06-79bf1207cf0a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d32bee34-3aaf-3f9a-cb7f-1da82fdad254"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448bee34-7aaf-4f9a-bb7f-1da82fdad254");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2d92f37-7fb8-494e-bc06-79bf1207cf0a");
        }
    }
}
