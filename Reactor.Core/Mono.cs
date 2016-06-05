﻿using Reactive.Streams;
using Reactor.Core.flow;
using Reactor.Core.publisher;
using Reactor.Core.scheduler;
using Reactor.Core.subscriber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactor.Core
{

    /// <summary>
    /// Extension methods for IMono sources.
    /// </summary>
    public static class Mono
    {
        // ---------------------------------------------------------------------------------------------------------
        // Enter the reactive world
        // ---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Create a new IPublisher that will only emit the passed data then onComplete.
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="value">The unique data to emit</param>
        /// <returns>The new IPublisher instance</returns>
        public static IMono<T> Just<T>(T value)
        {
            return new PublisherJust<T>(value);
        }

        /// <summary>
        /// Returns an empty instance which completes the ISubscribers immediately.
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <returns>The shared Empty instance.</returns>
        public static IMono<T> Empty<T>()
        {
            return PublisherEmpty<T>.Instance;
        }

        /// <summary>
        /// Returns an never instance which sets an empty ISubscription and
        /// does nothing further.
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <returns>The shared Never instance.</returns>
        public static IMono<T> Never<T>()
        {
            return PublisherNever<T>.Instance;
        }

        public static IMono<T> Any<T>(params IMono<T>[] sources)
        {
            // TODO implement Any
            throw new NotImplementedException();
        }

        public static IMono<T> Any<T>(IEnumerable<IMono<T>>[] sources)
        {
            // TODO implement Any
            throw new NotImplementedException();
        }

        public static IMono<T> Create<T>(Action<IMonoEmitter<T>> generator)
        {
            // TODO implement Create
            throw new NotImplementedException();
        }

        public static IMono<T> Defer<T>(Func<IMono<T>> supplier)
        {
            return new PublisherDefer<T>(supplier);
        }

        public static IMono<long> Delay(TimeSpan delay)
        {
            return Delay(delay, DefaultScheduler.Instance);
        }

        public static IMono<long> Delay(TimeSpan delay, TimedScheduler scheduler)
        {
            // TODO implement Delay
            throw new NotImplementedException();
        }

        public static IMono<Void> Empty<T>(IPublisher<T> source)
        {
            // TODO implement Empty
            throw new NotImplementedException();
        }

        public static IMono<T> Error<T>(Exception ex)
        {
            // TODO implement Error
            throw new NotImplementedException();
        }

        public static IMono<T> First<T>(params IMono<T>[] sources)
        {
            // TODO implement First
            throw new NotImplementedException();
        }

        public static IMono<T> From<T>(IPublisher<T> source)
        {
            // TODO implement From
            throw new NotImplementedException();
        }

        public static IMono<T> From<T>(Func<T> generator, bool nullMeansEmpty = false)
        {
            return new PublisherFunc<T>(generator, nullMeansEmpty);
        }

        public static IMono<Void> From(Task task)
        {
            // TODO implement From
            throw new NotImplementedException();
        }

        public static IMono<T> From<T>(Task<T> task)
        {
            // TODO implement From
            throw new NotImplementedException();
        }

        public static IMono<Void> From(Action action)
        {
            // TODO implement From
            throw new NotImplementedException();
        }

        public static IMono<T> IgnoreElements<T>(IPublisher<T> source)
        {
            // TODO implement IgnoreElements
            throw new NotImplementedException();
        }

        public static IMono<T> Using<T, R>(Func<R> resourceFactory, Func<R, IMono<T>> monoFactory, Action<R> resourceDisposer, bool eager = true)
        {
            // TODO implement Using
            throw new NotImplementedException();
        }

        public static IMono<Tuple<T1, T2>> When<T1, T2>(IMono<T1> m1, IMono<T2> m2, bool delayErrors = false)
        {
            // TODO implement When
            throw new NotImplementedException();
        }

        public static IMono<Tuple<T1, T2, T3>> When<T1, T2, T3>(
            IMono<T1> m1, IMono<T2> m2, 
            IMono<T3> m3,
            bool delayErrors = false)
        {
            // TODO implement When
            throw new NotImplementedException();
        }

        public static IMono<Tuple<T1, T2, T3, T4>> When<T1, T2, T3, T4>(
            IMono<T1> m1, IMono<T2> m2,
            IMono<T3> m3, IMono<T4> m4,
            bool delayErrors = false)
        {
            // TODO implement When
            throw new NotImplementedException();
        }

        public static IMono<Tuple<T1, T2, T3, T4, T5>> When<T1, T2, T3, T4, T5>(
            IMono<T1> m1, IMono<T2> m2,
            IMono<T3> m3, IMono<T4> m4,
            IMono<T5> m5,
            bool delayErrors = false)
        {
            // TODO implement When
            throw new NotImplementedException();
        }

        public static IMono<Tuple<T1, T2, T3, T4, T5, T6>> When<T1, T2, T3, T4, T5, T6>(
            IMono<T1> m1, IMono<T2> m2,
            IMono<T3> m3, IMono<T4> m4,
            IMono<T5> m5, IMono<T6> m6,
            bool delayErrors = false)
        {
            // TODO implement When
            throw new NotImplementedException();
        }

        public static IMono<T[]> When<T>(bool delayErrors = false, params IMono<T>[] sources)
        {
            // TODO implement When
            throw new NotImplementedException();
        }

        public static IMono<T[]> When<T>(IEnumerable<IMono<T>> sources, bool delayErrors = false)
        {
            // TODO implement When
            throw new NotImplementedException();
        }

        public static IMono<R> Zip<T, R>(Func<T[], R> zipper, params IMono<T>[] sources)
        {
            // TODO implement Zip
            throw new NotImplementedException();
        }

        public static IMono<R> Zip<T, R>(IEnumerable<IMono<T>> sources, Func<T[], R> zipper)
        {
            // TODO implement Zip
            throw new NotImplementedException();
        }

        // ---------------------------------------------------------------------------------------------------------
        // Transform the reactive world
        // ---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Transform the items emitted by this IFlux by applying a function to each item.
        /// </summary>
        /// <typeparam name="T">The input value type</typeparam>
        /// <typeparam name="R">The output value type</typeparam>
        /// <param name="source">The source IFlux</param>
        /// <param name="mapper">The mapper from Ts to Rs</param>
        /// <returns>The new IFlux instance</returns>
        public static IMono<R> Map<T, R>(this IMono<T> source, Func<T, R> mapper)
        {
            return new PublisherMap<T, R>(source, mapper);
        }
        
        public static R As<T, R>(this IMono<T> source, Func<IMono<T>, R> transformer)
        {
            return transformer(source);
        }

        public static IMono<Tuple<T, U>> And<T, U>(this IMono<T> source, IMono<U> other)
        {
            return When(source, other);
        }

        public static IMono<R> Cast<T, R>(this IMono<T> source) where T: class where R : class
        {
            return Map(source, v =>
            {
                R r = v as R;
                if (v != null && r == null)
                {
                    throw new InvalidCastException();
                }
                return r;
            });
        }

        public static IMono<T> Cache<T>(this IMono<T> source)
        {
            // TODO implement Cache
            throw new NotImplementedException();
        }

        public static IMono<R> Compose<T, R>(this IMono<T> source, Func<IMono<T>, IMono<R>> composer)
        {
            return Defer(() => composer(source));
        }

        public static IFlux<T> ConcatWith<T>(this IMono<T> source, IPublisher<T> other, bool delayErrors = false)
        {
            if (delayErrors)
            {
                return Flux.ConcatDelayError(source, other);
            }
            return Flux.Concat<T>(source, other);
        }

        public static IMono<T> DefaultIfEmpty<T>(this IMono<T> source, T defaultValue)
        {
            // TODO implement DefaultIfEmpty
            throw new NotImplementedException();
        }

        public static IMono<T> DelaySubscription<T>(this IMono<T> source, TimeSpan delay)
        {
            return DelaySubscription(source, delay, DefaultScheduler.Instance);
        }

        public static IMono<T> DelaySubscription<T>(this IMono<T> source, TimeSpan delay, TimedScheduler scheduler)
        {
            // TODO implement DelaySubscription
            throw new NotImplementedException();
        }

        public static IMono<T> DelaySubscription<T, U>(this IMono<T> source, IPublisher<U> other)
        {
            // TODO implement DelaySubscription
            throw new NotImplementedException();
        }

        public static IMono<T> Dematerialize<T>(this IMono<ISignal<T>> source)
        {
            // TODO implement Dematerialize
            throw new NotImplementedException();
        }

        public static IMono<T> DoAfterTerminate<T>(this IMono<T> source, Action onAfterTerminate)
        {
            return PublisherPeek<T>.withOnAfterTerminate(source, onAfterTerminate);
        }

        public static IMono<T> DoAfterNext<T>(this IMono<T> source, Action<T> onAfterNext)
        {
            return PublisherPeek<T>.withOnAfterNext(source, onAfterNext);
        }

        public static IMono<T> DoOnCancel<T>(this IMono<T> source, Action onCancel)
        {
            return PublisherPeek<T>.withOnCancel(source, onCancel);
        }

        public static IMono<T> DoOnComplete<T>(this IMono<T> source, Action onComplete)
        {
            return PublisherPeek<T>.withOnComplete(source, onComplete);
        }

        public static IMono<T> DoOnError<T>(this IMono<T> source, Action<Exception> onError)
        {
            return PublisherPeek<T>.withOnError(source, onError);
        }

        public static IMono<T> DoOnError<T, E>(this IMono<T> source, Action<E> onError) where E : Exception
        {
            return DoOnError(source, e =>
            {
                if (e is E)
                {
                    onError(e as E);
                }
            });
        }

        public static IMono<T> DoOnError<T>(this IMono<T> source, Func<Exception, bool> predicate, Action<Exception> onError)
        {
            return DoOnError(source, e =>
            {
                if (predicate(e))
                {
                    onError(e);
                }
            });
        }

        public static IMono<T> DoOnNext<T>(this IMono<T> source, Action<T> onNext)
        {
            return PublisherPeek<T>.withOnNext(source, onNext);
        }

        public static IMono<T> DoOnRequest<T>(this IMono<T> source, Action<long> onRequest)
        {
            return PublisherPeek<T>.withOnRequest(source, onRequest);
        }

        public static IMono<T> DoOnSubscribe<T>(this IMono<T> source, Action<ISubscription> onSubscribe)
        {
            return PublisherPeek<T>.withOnSubscribe(source, onSubscribe);
        }

        public static IMono<T> DoOnTerminate<T>(this IMono<T> source, Action onTerminate)
        {
            return PublisherPeek<T>.withOnTerminate(source, onTerminate);
        }

        public static IMono<Timed<T>> Elapsed<T>(this IMono<T> source)
        {
            return Elapsed(source, DefaultScheduler.Instance);
        }

        public static IMono<Timed<T>> Elapsed<T>(this IMono<T> source, TimedScheduler scheduler)
        {
            // TODO implement Elapsed
            throw new NotImplementedException();
        }

        public static IFlux<T> Filter<T>(this IFlux<T> source, Func<T, bool> predicate)
        {
            return new PublisherFilter<T>(source, predicate);
        }

        public static IFlux<R> FlatMap<T, R>(this IMono<T> source, Func<T, IPublisher<R>> mapper)
        {
            // TODO implement Elapsed
            throw new NotImplementedException();
        }

        public static IMono<R> FlatMap<T, R>(this IMono<T> source, Func<T, IMono<R>> mapper)
        {
            // TODO implement Elapsed
            throw new NotImplementedException();
        }

        public static IFlux<R> FlatMap<T, R>(this IMono<T> source, Func<T, IEnumerable<R>> mapper)
        {
            // TODO implement Elapsed
            throw new NotImplementedException();
        }

        public static IFlux<R> FlatMap<T, R>(this IMono<T> source, 
            Func<T, IPublisher<R>> onNextMapper, Func<Exception, IPublisher<R>> onErrorMapper,
            Func<IPublisher<R>> onCompleteMapper)
        {
            // TODO implement Elapsed
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts this IMono into an IFlux.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="source">The source to convert</param>
        /// <returns>The IFlux instance</returns>
        public static IFlux<T> ToFlux<T>(this IMono<T> source)
        {
            if (source is IFlux<T>)
            {
                return source as IFlux<T>;
            }
            if (source is IFuseable)
            {
                return new PublisherWrapFuseable<T>(source);
            }
            return new PublisherWrap<T>(source);
        }

        public static IMono<bool> HasElement<T>(this IMono<T> source)
        {
            // TODO implement HasElement
            throw new NotImplementedException();
        }

        public static IMono<T> Hide<T>(this IMono<T> source)
        {
            return new PublisherHide<T>(source);
        }

        public static IMono<T> IgnoreElement<T>(this IMono<T> source)
        {
            // TODO implement IgnoreElement
            throw new NotImplementedException();
        }

        public static IMono<T> MapError<T>(this IMono<T> source, Func<Exception, Exception> mapper)
        {
            return MapError(source, e => true, mapper);
        }

        public static IMono<T> MapError<T, E>(this IMono<T> source, Func<E, Exception> mapper) where E : Exception
        {
            return MapError(source, e => e is E, e => mapper(e as E));
        }

        public static IMono<T> MapError<T>(this IMono<T> source, Func<Exception, bool> predicate, Func<Exception, Exception> mapper)
        {
            // TODO implement MapError
            throw new NotImplementedException();
        }

        public static IMono<ISignal<T>> Materialize<T>(this IMono<T> source)
        {
            // TODO implement Materialize
            throw new NotImplementedException();
        }

        public static IMono<T> MergeWith<T>(this IMono<T> source, IMono<T> other)
        {
            // TODO implement MergeWith
            throw new NotImplementedException();
        }

        public static IMono<IMono<T>> Nest<T>(this IMono<T> source)
        {
            return Just(source);
        }

        public static IMono<T> Or<T>(this IMono<T> source, IMono<T> other)
        {
            return First(source, other);
        }

        public static IMono<T> Otherwise<T>(this IMono<T> source, Func<Exception, IMono<T>> resumeFunction)
        {
            return Otherwise(source, e => true, resumeFunction);
        }

        public static IMono<T> Otherwise<T, E>(this IMono<T> source, Func<E, IMono<T>> resumeFunction) where E : Exception
        {
            return Otherwise(source, e => e is E, e => resumeFunction(e as E));
        }

        public static IMono<T> Otherwise<T>(this IMono<T> source, Func<Exception, bool> predicate, Func<Exception, IMono<T>> resumeFunction)
        {
            // TODO implement Otherwise
            throw new NotImplementedException();
        }

        public static IMono<T> OtherwiseIfEmpty<T>(this IMono<T> source, IMono<T> other)
        {
            return First(source, other);
        }

        public static IMono<T> OtherwiseReturn<T>(this IMono<T> source, T value)
        {
            return OtherwiseReturn(source, e => true, value);
        }

        public static IMono<T> OtherwiseReturn<T, E>(this IMono<T> source, T value) where E : Exception
        {
            return OtherwiseReturn(source, e => e is E, value);
        }

        public static IMono<T> OtherwiseReturn<T>(this IMono<T> source, Func<Exception, bool> predicate, T value)
        {
            // TODO implement OtherwiseReturn
            throw new NotImplementedException();
        }

        public static IMono<T> OnTerminateDetach<T>(this IMono<T> source)
        {
            // TODO implement OnTerminateDetach
            throw new NotImplementedException();
        }

        public static IMono<R> Publish<T, R>(this IMono<T> source, Func<IMono<T>, IMono<R>> transformer)
        {
            // TODO implement Publish
            throw new NotImplementedException();
        }

        public static IMono<T> PublishOn<T>(this IMono<T> source, Scheduler scheduler)
        {
            // TODO implement PublishOn
            throw new NotImplementedException();
        }

        public static IFlux<T> Repeat<T>(this IMono<T> source)
        {
            // TODO implement Repeat
            throw new NotImplementedException();
        }

        public static IFlux<T> Repeat<T>(this IMono<T> source, long times)
        {
            // TODO implement Repeat
            throw new NotImplementedException();
        }

        public static IFlux<T> Repeat<T>(this IMono<T> source, Func<bool> predicate)
        {
            // TODO implement Repeat
            throw new NotImplementedException();
        }

        public static IFlux<T> Repeat<T>(this IMono<T> source, long times, Func<bool> predicate)
        {
            // TODO implement Repeat
            throw new NotImplementedException();
        }

        public static IFlux<T> RepeatWhen<T>(this IMono<T> source, Func<IFlux<long>, IPublisher<object>> whenFunction)
        {
            // TODO implement RepeatWhen
            throw new NotImplementedException();
        }

        public static IMono<T> RepeatWhenEmpty<T>(this IMono<T> source, Func<IFlux<long>, IPublisher<object>> whenFunction)
        {
            // TODO implement Repeat
            throw new NotImplementedException();
        }

        public static IMono<T> RepeatWhenEmpty<T>(this IMono<T> source, long times, Func<IFlux<long>, IPublisher<object>> whenFunction)
        {
            // TODO implement Repeat
            throw new NotImplementedException();
        }

        public static IMono<T> Retry<T>(this IMono<T> source)
        {
            // TODO implement Retry
            throw new NotImplementedException();
        }

        public static IMono<T> Retry<T>(this IMono<T> source, long times)
        {
            // TODO implement Retry
            throw new NotImplementedException();
        }

        public static IMono<T> Retry<T>(this IMono<T> source, Func<Exception> predicate)
        {
            // TODO implement Retry
            throw new NotImplementedException();
        }

        public static IMono<T> Retry<T>(this IMono<T> source, long times, Func<Exception> predicate)
        {
            // TODO implement Retry
            throw new NotImplementedException();
        }

        public static IMono<T> RetryWhen<T>(this IMono<T> source, Func<IFlux<Exception>, IPublisher<object>> whenFunction)
        {
            // TODO implement RepeatWhen
            throw new NotImplementedException();
        }

        public static IMono<T> SubscribeOn<T>(this IMono<T> source, Scheduler scheduler)
        {
            // TODO implement SubscribeOn
            throw new NotImplementedException();
        }

        public static IMono<Void> Then<T>(this IMono<T> source)
        {
            return Empty<T>(source);
        }

        public static IMono<R> Then<T, R>(this IMono<T> source, Func<T, IMono<R>> transformer)
        {
            // TODO implement Then
            throw new NotImplementedException();
        }

        public static IMono<R> Then<T, R>(this IMono<T> source, IMono<R> other)
        {
            // TODO implement Then
            throw new NotImplementedException();
        }

        public static IMono<R> Then<T, R>(this IMono<T> source, Func<IMono<R>> other)
        {
            return Then(source, Defer(other));
        }

        public static IFlux<R> ThenMany<T, R>(this IMono<T> source, IFlux<R> other)
        {
            // TODO implement Then
            throw new NotImplementedException();
        }

        public static IFlux<R> ThenMany<T, R>(this IMono<T> source, Func<IFlux<R>> other)
        {
            return ThenMany(source, Flux.Defer(other));
        }

        public static IMono<T> Timeout<T>(this IMono<T> source, TimeSpan timeout, IMono<T> fallback = null)
        {
            return Timeout(source, timeout, DefaultScheduler.Instance);
        }

        public static IMono<T> Timeout<T>(this IMono<T> source, TimeSpan timeout, TimedScheduler scheduler, IMono<T> fallback = null)
        {
            // TODO implement Timeout
            throw new NotImplementedException();
        }


        public static IMono<T> Timeout<T, U>(this IMono<T> source, IPublisher<U> firstTimeout, IMono<T> fallback = null)
        {
            // TODO implement Timeout
            throw new NotImplementedException();
        }

        public static IMono<Timed<T>> Timestamp<T>(this IMono<T> source)
        {
            return Timestamp(source, DefaultScheduler.Instance);
        }

        public static IMono<Timed<T>> Timestamp<T>(this IMono<T> source, TimedScheduler scheduler)
        {
            return Map(source, v => new Timed<T>(v, scheduler.NowUtc));
        }

        /// <summary>
        /// Convert this IMono into an IObservable.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="source">The source IMono.</param>
        /// <returns>The new IObservable.</returns>
        public static IObservable<T> ToObservable<T>(this IMono<T> source)
        {
            return new PublisherAsObservable<T>(source);
        }

        public static Task<T> ToTask<T>(this IMono<T> source)
        {
            // TODO implement Timeout
            throw new NotImplementedException();
        }

        public static Task ToTask(this IMono<Void> source)
        {
            // TODO implement Timeout
            throw new NotImplementedException();
        }

        // ---------------------------------------------------------------------------------------------------------
        // Leave the reactive world
        // ---------------------------------------------------------------------------------------------------------

        public static T Block<T>(this IMono<T> source)
        {
            // TODO implement Block
            throw new NotImplementedException();
        }

        public static T Block<T>(this IMono<T> source, TimeSpan timeout)
        {
            // TODO implement Block
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subscribes to the IPublisher and ignores all of its signals.
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="source">The source IPublisher</param>
        /// <returns>The IDisposable that allows cancelling the subscription.</returns>
        public static IDisposable Subscribe<T>(this IMono<T> source)
        {
            var d = new CallbackSubscriber<T>(v => { }, e => { ExceptionHelper.OnErrorDropped(e); }, () => { });
            source.Subscribe(d);
            return d;
        }

        /// <summary>
        /// Subscribes to the IPublisher and consumes only its OnNext signals.
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="source">The source IPublisher</param>
        /// <param name="onNext">The callback for the OnNext signals</param>
        /// <returns>The IDisposable that allows cancelling the subscription.</returns>
        public static IDisposable Subscribe<T>(this IMono<T> source, Action<T> onNext)
        {
            var d = new CallbackSubscriber<T>(onNext, e => { ExceptionHelper.OnErrorDropped(e); }, () => { });
            source.Subscribe(d);
            return d;
        }

        /// <summary>
        /// Subscribes to the IPublisher and consumes only its OnNext signals.
        /// </summary>
        /// <remarks>
        /// If the <paramref name="onNext"/> callback crashes, the error is routed
        /// to <paramref name="onError"/> callback.
        /// If the <paramref name="onError"/> callback crashes, the error is routed to the
        /// global error hanlder in <see cref="ExceptionHelper.OnErrorDropped(Exception)"/>.
        /// </remarks>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="source">The source IPublisher</param>
        /// <param name="onNext">The callback for the OnNext signals</param>
        /// <param name="onError">The callback for the OnError signals</param>
        /// <returns>The IDisposable that allows cancelling the subscription.</returns>
        public static IDisposable Subscribe<T>(this IMono<T> source, Action<T> onNext, Action<Exception> onError)
        {
            var d = new CallbackSubscriber<T>(onNext, onError, () => { });
            source.Subscribe(d);
            return d;
        }

        /// <summary>
        /// Subscribes to the IPublisher and consumes only its OnNext signals.
        /// </summary>
        /// <remarks>
        /// If the <paramref name="onNext"/> callback crashes, the error is routed
        /// to <paramref name="onError"/> callback.
        /// If the <paramref name="onError"/> or <paramref name="onComplete"/> callbackcrashes, 
        /// the error is routed to the
        /// global error hanlder in <see cref="ExceptionHelper.OnErrorDropped(Exception)"/>.
        /// </remarks>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="source">The source IPublisher</param>
        /// <param name="onNext">The callback for the OnNext signals.</param>
        /// <param name="onError">The callback for the OnError signal.</param>
        /// <param name="onComplete">The callback for the OnComplete signal.</param>
        /// <returns>The IDisposable that allows cancelling the subscription.</returns>
        public static IDisposable Subscribe<T>(this IMono<T> source, Action<T> onNext, Action<Exception> onError, Action onComplete)
        {
            var d = new CallbackSubscriber<T>(onNext, onError, onComplete);
            source.Subscribe(d);
            return d;
        }

        public static E SubscribeWith<T, E>(this IMono<T> source, E subscriber) where E : ISubscriber<T>
        {
            source.Subscribe(subscriber);
            return subscriber;
        }

        public static IEnumerable<T> ToEnumerable<T>(this IMono<T> source)
        {
            // TODO implement ToEnumerable
            throw new NotImplementedException();
        }
    }
}