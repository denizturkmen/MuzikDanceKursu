﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.DataAccessLayer.Concrete.EntityFrameWork
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new MuzikDbContext();

            if (!context.Database.GetPendingMigrations().Any())
            {
                if (!context.Teachers.Any())
                {
                    context.Teachers.AddRange(Teachers);
                }

                if (!context.Lessons.Any())
                {

                }

                if (!context.Branches.Any())
                {
                    context.Branches.AddRange(Branches);
                }

            }

            context.SaveChanges();
        }

        private static Teacher[] Teachers=
        {
            new Teacher() { TeacherName = "Deniz",Education = "Başkent Universite",Image = "1.jpg",BranchId = 1,LessonId = 1},
            new Teacher() { TeacherName = "Mehmet",Education = "Başkent Universite",Image = "2.jpg",BranchId = 2,LessonId = 2},
            new Teacher() { TeacherName = "Eren",Education = "Oka Universite",Image = "3.jpg",BranchId = 3,LessonId = 3},
            new Teacher() { TeacherName = "Besra",Education = "DokuzEylul Universite",Image = "1.jpg",BranchId = 4,LessonId = 2},
            new Teacher() { TeacherName = "Deniz",Education = "Başkent Universite",Image = "1.jpg",BranchId = 3,LessonId = 4},
        };

        private static Branch[] Branches =
        {
            new Branch() {Education = "Başkent", BranchName = "Opera"},
            new Branch() {Education = "Başkent", BranchName = "Turk Sanat Muziği"},
            new Branch() {Education = "Başkent", BranchName = "Jazz"},
            new Branch() {Education = "Başkent", BranchName = "Ortadoğu"},
            new Branch() {Education = "Başkent", BranchName = "Sallıycak Kalmadı"},

        };
    }

   

}