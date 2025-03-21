﻿using Betalgo.Ranul.OpenAI.Interfaces;
using Betalgo.Ranul.OpenAI.ObjectModels;
using OpenAI.Playground.ExtensionsAndHelpers;

namespace OpenAI.Playground.TestHelpers;

internal static class EditTestHelper
{
    public static async Task RunSimpleEditCreateTest(IOpenAIService sdk)
    {
        ConsoleExtensions.WriteLine("Edit Create Testing is starting:", ConsoleColor.Cyan);

        try
        {
            ConsoleExtensions.WriteLine("Edit Create Test:", ConsoleColor.DarkCyan);
            var completionResult = await sdk.Edit.CreateEdit(new()
            {
                Input = "What day of the wek is it?",
                Instruction = "Fix the spelling mistakes"
            }, Models.TextEditDavinciV1);

            if (completionResult.Successful)
            {
                Console.WriteLine(completionResult.Choices.FirstOrDefault());
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new("Unknown Error");
                }

                Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}